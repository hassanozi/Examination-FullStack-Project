using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using examinationAPI.DTOs.Questions;
using examinationAPI.Helpers;
using examinationAPI.Models;
using examinationAPI.Repositories;

namespace examinationAPI.Services
{
    public class QuestionService(IRepository<Question> questionRepo)
    {
        public IEnumerable<GetQuestionsDTO> GetAllQuestions()
        {
            var questionsData = questionRepo.GetAll().Map<GetQuestionsDTO>();
            return questionsData;
        }

        public IEnumerable<GetQuestionsDTO> GetCourseQuestions(int courseId)
        {
            var questionsData = questionRepo
            .GetAll()
            .Where(q =>
                q.ExamQuestions.Any(eq => eq.Exams.CourseId == courseId))
                .Map<GetQuestionsDTO>();
                
            // var questionsDTO = questionsData.Map<GetQuestionsDTO>();
            return questionsData;
        }
        public async Task<bool> AddQuestionAsync(AddQuestionDTO addQuestionDTO)
        {
            bool exists = await questionRepo
             .Get(q => q.Title == addQuestionDTO.Title) != null;
            
            if (exists)
                throw new InvalidOperationException("This question already exists");

            var questionEntity = addQuestionDTO.MapOne<Question>();
            questionRepo.Add(questionEntity);
            await questionRepo.SaveChanges();
            return true;
        }
    }
}