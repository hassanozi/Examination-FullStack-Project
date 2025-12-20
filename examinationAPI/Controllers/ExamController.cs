using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using examinationAPI.DTOs.Exams;
using examinationAPI.Helpers;
using examinationAPI.Services;
using examinationAPI.ViewModels.Exams;
using Microsoft.AspNetCore.Mvc;

namespace examinationAPI.Controllers
{
    [ApiController]
    [Route("[controller]/[Action]")]
    public class ExamController(ExamService examService,IMapper _mapper) : ControllerBase
    {
        [HttpGet]
        public IEnumerable<GetExamsViewModel> GetExams()
        {
            var exams = examService.GetExams();
            var result = _mapper.Map<IEnumerable<GetExamsViewModel>>(exams);
            return result;
        }

        [HttpPost]
        public async Task<bool> AddExam(AddExamViewModel addExamViewModel)
        {
            // if (!ModelState.IsValid)
            //     return BadRequest(ModelState);

            var result = addExamViewModel.MapOne<AddExamDTO>();

            await examService.AddExamAsync(result);

            return true;
        }
    }
}