using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using examinationAPI.DTOs.Questions;
using examinationAPI.Services;
using examinationAPI.ViewModels.Questions;
using Microsoft.AspNetCore.Mvc;

namespace examinationAPI.Controllers
{
    [ApiController]
    [Route("[controller]/[Action]")]
    public class QuestionController(QuestionService questionService, IMapper mapper) : ControllerBase
    {
        [HttpGet]
        public IEnumerable<GetQuestionsViewModel> GetAllQuestions()
        {
           var questions = questionService.GetAllQuestions();
           var result = mapper.Map<IEnumerable<GetQuestionsViewModel>>(questions);
           return result;
        }

        [HttpGet]
        public IEnumerable<GetQuestionsViewModel> GetCourseQuestions(int courseId)
        {
           var questions = questionService.GetCourseQuestions(courseId);

           var result = mapper.Map<IEnumerable<GetQuestionsViewModel>>(questions);

            return result;
        }

        [HttpPost]
        public async Task<bool> AddQuestion(AddQuestionViewModel addQuestionViewModel)
        {
            var addQuestionDTO = mapper.Map<AddQuestionDTO>(addQuestionViewModel);
            await questionService.AddQuestionAsync(addQuestionDTO);
            return true;
        }
    }
}