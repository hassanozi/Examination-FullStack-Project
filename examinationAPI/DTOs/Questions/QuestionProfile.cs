using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using examinationAPI.Models;
using examinationAPI.ViewModels.Questions;

namespace examinationAPI.DTOs.Questions
{
    public class QuestionProfile : Profile
    {
        public QuestionProfile()
        {
            CreateMap<AddQuestionDTO, Question>().ReverseMap();
            CreateMap<GetQuestionsDTO,Question>().ReverseMap();
            CreateMap<AddQuestionViewModel,AddQuestionDTO>().ReverseMap();
            CreateMap<AddQuestionDTO,Question>().ReverseMap();
        }
    }
}