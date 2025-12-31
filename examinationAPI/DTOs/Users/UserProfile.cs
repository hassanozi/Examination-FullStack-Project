using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using examinationAPI.Models;
using examinationAPI.ViewModels.Users;

namespace examinationAPI.DTOs.Users
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<CreateUserDTO, User>().ReverseMap();
            CreateMap<CreateUserViewModel, CreateUserDTO>().ReverseMap();
            CreateMap<GetUsersDTO,User>().ReverseMap();
        }
    }
}