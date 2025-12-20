using examinationAPI.DTOs.Exams;
using examinationAPI.Helpers;
using examinationAPI.Models;
using examinationAPI.Repositories;
using examinationAPI.ViewModels.Exams;

namespace examinationAPI.Services
{
    public class ExamService(IRepository<Exam> examRepo)
    {
        public IEnumerable<GetExamsDTO> GetExams()
        {
            var examEntities = examRepo.GetAll();
            var examDTOs = examEntities.Map<GetExamsDTO>();
            return examDTOs;
        }

        public async Task<bool> AddExamAsync(AddExamDTO addExamDTO)
        {
            bool exists = await examRepo
             .Get(e => e.Title == addExamDTO.Title) != null;
            
            if (exists)
                throw new InvalidOperationException("This question already exists");

            var examEntity = addExamDTO.MapOne<Exam>();
            examRepo.Add(examEntity);
            await examRepo.SaveChanges();
            return true;
        }
    }
}