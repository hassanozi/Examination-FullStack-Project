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
            var exists =  _examRepo
                .Exists(examId) ;
               

            if (exists)
                throw new Exception("Course title already exists");


            var exam = await _examRepo.Get(e => e.Id == examId);
            if (exam == null)
                throw new Exception("Exam not found");

            var question = await _questionRepo.Get(q => q.Id == questionId);
            if (question == null)
                throw new Exception("Question not found");

            var exists2 = await _examQuestionRepo
                .Get(x => x.ExamId == examId && x.QuestionId == questionId);

            if (exists2 != null)
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