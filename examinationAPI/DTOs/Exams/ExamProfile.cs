using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using examinationAPI.Models;
using examinationAPI.ViewModels.Exams;

namespace examinationAPI.DTOs.Exams
{
    public class ExamProfile : Profile
    {
        public ExamProfile()
        {
            CreateMap<Exam, GetExamsDTO>().ReverseMap();
            CreateMap<AddExamDTO, Exam>().ReverseMap();
            CreateMap<AddExamViewModel, AddExamDTO>().ReverseMap();
        }
    }
}