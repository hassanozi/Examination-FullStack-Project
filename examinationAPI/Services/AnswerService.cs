using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using examinationAPI.Models;
using examinationAPI.Repositories;
using Microsoft.EntityFrameworkCore;

namespace examinationAPI.Services
{
    public class AnswerService
    {
        private readonly IRepository<Answer> _answerRepo;

        public AnswerService(IRepository<Answer> answerRepo)
        {
            _answerRepo = answerRepo;
        }

        // Admin / Instructor: See all answers in an exam
        public async Task<IEnumerable<Answer>> GetAnswersByExam(int examId)
        {
            return await _answerRepo.GetAll()
                .Where(a => a.ExamQuestion.ExamId == examId)
                .ToListAsync();
        }

        // Student profile / history
        public async Task<IEnumerable<Answer>> GetAnswersByStudent(int userId)
        {
            return await _answerRepo.GetAll()
                .Where(a => a.UserId == userId)
                .ToListAsync();
        }

        // Most used: View student result
        public async Task<IEnumerable<Answer>> GetAnswersByExamAndStudent(int examId, int userId)
        {
            return await _answerRepo.GetAll()
                .Where(a => a.UserId == userId &&
                            a.ExamQuestion.ExamId == examId)
                .ToListAsync();
        }

        // Review how students answered a specific question
        public async Task<IEnumerable<Answer>> GetAnswersByQuestion(int examQuestionId)
        {
            return await _answerRepo.GetAll()
                .Where(a => a.ExamQuestionId == examQuestionId)
                .ToListAsync();
        }
    }
}