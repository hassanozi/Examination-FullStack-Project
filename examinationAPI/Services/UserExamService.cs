using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using examinationAPI.DTOs.StudentExam;
using examinationAPI.Models;
using examinationAPI.Models.Enums;
using examinationAPI.Repositories;

namespace examinationAPI.Services
{
    public class UserExamService(
        IRepository<User> _userRepo, IRepository<Exam> _examRepo, 
        IRepository<Answer> _answerRepo, IRepository<ExamQuestion> _examQuestionRepo)
    {
        public async Task StartExam(int examId, int userId)
        {
         
            var user = await _userRepo.GetById(userId);
            if (user == null)
                throw new Exception("User not found");

            
            if (user.SystemRole != SystemRole.Student)
                throw new UnauthorizedAccessException("Only students can take exams");

        
            var exam = await _examRepo.GetById(examId);
            if (exam == null)
                throw new Exception("Exam not found");

           
            if (!exam.IsActive)
                throw new Exception("Exam is not active");

            var alreadyStarted = _answerRepo.Get(a => a.UserId == userId && a.ExamQuestion.ExamId == examId);

            if (alreadyStarted == null)
                throw new Exception("You already started this exam");

          
            var examQuestions = _examQuestionRepo.GetAll()
                .Where(q => q.ExamId == examId)
                .ToList();

            if (!examQuestions.Any())
                throw new Exception("Exam has no questions");

            // 7️⃣ Create empty answers
            foreach (var question in examQuestions)
            {
                _answerRepo.Add(new Answer
                {
                    UserId = userId,
                    ExamQuestionId = question.Id,
                    Score = null,        
                });
            }

            await _answerRepo.SaveChanges();
        }


        public async Task SubmitAnswer(int examQuestionId, int userId, double score, double totalScore)
        {
            var answer = await _answerRepo
                .GetWithTracking(a => a.ExamQuestionId == examQuestionId && a.UserId == userId);

            if (answer == null)
                throw new Exception("You must start the exam first");

            var exam = answer.ExamQuestion;

            if (!exam.IsActive)
                throw new Exception("Exam is closed");

            if (answer.Score != null)
                throw new Exception("Answer already submitted");

            answer.Score = score;
            answer.TotalScore = totalScore;

            await _answerRepo.SaveChanges();
        }


        public async Task FinishExam(int examId, int userId)
        {
            var exam = await _examRepo.GetById(examId);
            if (exam == null)
                throw new Exception("Invalid exam");

            var totalQuestions = _examQuestionRepo
                .GetAll()
                .Count(q => q.ExamId == examId);

            var answered = _answerRepo.GetAll()
                .Count(a => a.UserId == userId && a.ExamQuestion.ExamId == examId);

            if (answered < totalQuestions)
                throw new Exception("You must answer all questions");

            // Optional: Mark ExamAttempt as Finished
        }

        public async Task<StudentExamResultDTO> GetStudentResult(
            int examId,
            int userId,
            int requesterId)
        {
            var requester = await _userRepo.GetById(requesterId);
            if (requester == null)
                throw new UnauthorizedAccessException();

            bool allowed =
                requester.SystemRole == SystemRole.Admin ||
                requester.SystemRole == SystemRole.Instructor ||
                requester.Id == userId;

            if (!allowed)
                throw new UnauthorizedAccessException("You can't view this result");

            var answers = _answerRepo.GetAll()
                .Where(a => a.UserId == userId &&
                            a.ExamQuestion.ExamId == examId)
                .ToList();

            if (!answers.Any())
                throw new Exception("Exam not taken");

            var total = answers.Sum(a => a.TotalScore ?? 0);
            var score = answers.Sum(a => a.Score ?? 0);

            return new StudentExamResultDTO
            {
                ExamId = examId,
                UserId = userId,
                TotalScore = total,
                StudentScore = score,
                Percentage = total == 0 ? 0 : Math.Round((score / total) * 100, 2)
            };
        }


    }
}