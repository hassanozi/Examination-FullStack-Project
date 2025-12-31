using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using examinationAPI.DTOs.Users;
using examinationAPI.Helpers;
using examinationAPI.Services;
using examinationAPI.ViewModels;
using examinationAPI.ViewModels.Users;
using Microsoft.AspNetCore.Mvc;

namespace examinationAPI.Controllers
{
    [ApiController]
    [Route("[controller]/[Action]")]
    public class UserController(UserService userService, IMapper mapper) : ControllerBase
    {
        [HttpPost]
        public ActionResult Login(string UserName, string Password)
        {
            var token = GenerateToken.Generate("Hassano", "Hassan","Admin");

            return Ok(new {Token=token});
        }

        [HttpPost]
        public  async Task<bool> CreateUser(CreateUserViewModel createUserViewModel)
        {
            var newUser = createUserViewModel.MapOne<CreateUserDTO>();
            await userService.AddUser(newUser);
            return true; 
        }

        [HttpGet]
        public IEnumerable<GetUsersViewModel> GetUsers()
        {
            var users = userService.GetUsers();
            return mapper.Map<IEnumerable<GetUsersViewModel>>(users);
        }
    }
}