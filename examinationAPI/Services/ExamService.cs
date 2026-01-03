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
            var examEntities = examRepo.GetAll().Map<GetExamsDTO>();
            return examEntities;
        }

        public async Task<bool> AddExamAsync(AddExamDTO addExamDTO)
        {
            bool exists = await examRepo
             .Get(e => e.Title == addExamDTO.Title) != null;
            
            if (exists)
                throw new InvalidOperationException("This exam already exists");

            var examEntity = addExamDTO.MapOne<Exam>();
            examRepo.Add(examEntity);
            await examRepo.SaveChanges();
            return true;
        }

        public async Task UpdateExam(int examId, UpdateExamDTO updateExamDTO)
        {
            var exam = await examRepo.GetById(examId);
            if (exam == null)
                throw new Exception("Exam not found");

            updateExamDTO.MapTo(exam);   

            await examRepo.SaveChanges();
        }


        public async Task PublishExam(int examId)
        {
            var exam = await examRepo.GetById(examId);
            if (exam == null)
                throw new Exception("Exam not found");

            exam.IsActive = true;
            await examRepo.SaveChanges();
        }

        public async Task CloseExam(int examId)
        {
            var exam = await examRepo.GetById(examId);
            if (exam == null)
                throw new Exception("Exam not found");

            exam.IsActive = false;
            await examRepo.SaveChanges();
        }

        public async Task<GetExamDetailsDTO> GetExam(int examId)
        {
            var exam = await examRepo.GetById(examId);

            if (exam == null)
                throw new Exception("Exam not found");

            var examDto = exam.MapOne<GetExamDetailsDTO>();

            return examDto;
        }


        public async Task DeleteExam(int examId)
        {
            var exam = await examRepo.GetById(examId);
            if (exam == null)
                throw new Exception("Exam not found");

            examRepo.SoftDelete(exam);
            await examRepo.SaveChanges();
        }


    }
}