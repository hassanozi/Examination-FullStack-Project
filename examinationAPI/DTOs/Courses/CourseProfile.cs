using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using examinationAPI.Models;
using examinationAPI.ViewModels.Courses;

namespace examinationAPI.DTOs.Courses
{
    public class CourseProfile : Profile
    {
        public CourseProfile()
        {
            CreateMap<GetAllCoursesDTO,Course >().ReverseMap()
                .ForMember(
                    dst => dst.PreRequisetTitle,
                    opt => opt.MapFrom(src => src.PrerequisiteCourse!.Title)
                );
            CreateMap<GetAllCoursesDTO,GetAllCoursesViewModel>().ReverseMap();
            CreateMap<Course, GetCourseDTO>().ReverseMap();
            CreateMap<AddPreRequisetCourseDTO,Course>().ReverseMap();
            CreateMap<AddPreRequisetCourseViewModel,AddPreRequisetCourseDTO>().ReverseMap();

            
        }
    }
}