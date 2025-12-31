using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using examinationAPI.DTOs.ExamQuestion;
using examinationAPI.DTOs.StudentExam;
using examinationAPI.Models;
using examinationAPI.Models.Enums;
using examinationAPI.Repositories;

namespace examinationAPI.Services
{
    public class ExamQuestionService
    {
        private readonly IRepository<ExamQuestion> _examQuestionRepo;
        private readonly IRepository<Exam> _examRepo;
        private readonly IRepository<Question> _questionRepo;
        private readonly IRepository<Answer> _answerRepo;
        private readonly IRepository<User> _userRepo;

        public ExamQuestionService(
            IRepository<ExamQuestion> examQuestionRepo,
            IRepository<Exam> examRepo,
            IRepository<Question> questionRepo,
            IRepository<Answer> answerRepo,
            IRepository<User> userRepo)
        {
            _examQuestionRepo = examQuestionRepo;
            _examRepo = examRepo;
            _questionRepo = questionRepo;
            _answerRepo = answerRepo;
            _userRepo = userRepo;
        }
        public async Task AddQuestionToExam(int examId, int questionId)
        {
            var exam = await _examRepo.Get(e => e.Id == examId);
            if (exam == null)
                throw new Exception("Exam not found");

            var question = await _questionRepo.Get(q => q.Id == questionId);
            if (question == null)
                throw new Exception("Question not found");

            var exists = await _examQuestionRepo
                .Get(x => x.ExamId == examId && x.QuestionId == questionId);

            if (exists != null)
                throw new Exception("Question already in exam");

            var examQuestion = new ExamQuestion
            {
                ExamId = examId,
                QuestionId = questionId
            };

            _examQuestionRepo.Add(examQuestion);
            await _examQuestionRepo.SaveChanges();
        }

        public async Task RemoveQuestionFromExam(int examId, int questionId)
        {
            var eq = await _examQuestionRepo
                .Get(x => x.ExamId == examId && x.QuestionId == questionId);

            if (eq == null)
                throw new Exception("Question not in exam");

            var hasAnswers = _answerRepo
                .GetAll()
                .Any(a => a.ExamQuestionId == eq.Id);

            if (hasAnswers)
                throw new Exception("Cannot remove question – students already answered");

            _examQuestionRepo.SoftDelete(eq);
            await _examQuestionRepo.SaveChanges();
        }

        public async Task StartExam(int examId, int userId)
        {
            var examQuestions = _examQuestionRepo
                .GetAll()
                .Where(x => x.ExamId == examId)
                .ToList();

            if (!examQuestions.Any())
                throw new Exception("Exam has no questions");

            foreach (var eq in examQuestions)
            {
                var exists = _answerRepo
                    .GetAll()
                    .Any(a => a.UserId == userId && a.ExamQuestionId == eq.Id);

                if (!exists)
                {
                    _answerRepo.Add(new Answer
                    {
                        UserId = userId,
                        ExamQuestionId = eq.Id,
                        Score = null,
                        TotalScore = null
                    });
                }
            }

            await _answerRepo.SaveChanges();
        }

        public async Task SubmitAnswer(int examQuestionId, int userId, double score, double totalScore)
        {
            var answer = await _answerRepo
                .GetWithTracking(a => a.ExamQuestionId == examQuestionId && a.UserId == userId);

            if (answer == null)
                throw new Exception("Answer not found");

            answer.Score = score;
            answer.TotalScore = totalScore;

            await _answerRepo.SaveChanges();
        }

        public async Task<StudentExamResultDTO> GetStudentResult(int examId, int userId)
        {
            // var user = await _userRepo.Get(u => u.Id == userId);

            // if (user == null)
            //     throw new Exception("User not found");

            // if (user.SystemRole != SystemRole.Student)   // enum or Role table
            //     throw new Exception("Only students can view exam results");

            var answers = _answerRepo
                .GetAll()
                .Where(a => a.UserId == userId &&
                            a.ExamQuestion.ExamId == examId)
                .ToList();

            if (!answers.Any())
                throw new Exception("Student did not take this exam");

            var totalScore = answers.Sum(a => a.TotalScore ?? 0);
            var studentScore = answers.Sum(a => a.Score ?? 0);

            return new StudentExamResultDTO
            {
                ExamId = examId,
                UserId = userId,
                TotalScore = totalScore,
                StudentScore = studentScore,
                Percentage = (studentScore / totalScore) * 100
            };
        }

        public async Task<IEnumerable<StudentExamResultDTO>> GetExamResults(int examId)
        {
            var results = _answerRepo
                .GetAll()
                .Where(a => a.ExamQuestion.ExamId == examId)
                .GroupBy(a => a.UserId)
                .Select(g => new StudentExamResultDTO
                {
                    UserId = g.Key,
                    ExamId = examId,
                    StudentScore = g.Sum(x => x.Score ?? 0),
                    TotalScore = g.Sum(x => x.TotalScore ?? 0)
                })
                .ToList();

            return results;
        }

    }
}