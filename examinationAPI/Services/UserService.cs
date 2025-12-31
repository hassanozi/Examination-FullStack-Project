using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using examinationAPI.DTOs.Courses;
using examinationAPI.DTOs.Users;
using examinationAPI.Helpers;
using examinationAPI.Models;
using examinationAPI.Repositories;
using examinationAPI.ViewModels.Users;
using Microsoft.EntityFrameworkCore;

namespace examinationAPI.Services
{
    public class UserService(IRepository<User> userRepo)
    {
        public async Task<bool> AddUser(CreateUserDTO  createUserDTO)
        {
            try
            {
                var exists = await userRepo
                .Get(u => u.UserName == createUserDTO.UserName || u.Email == createUserDTO.Email) != null;
               
            if (exists)
                throw new Exception("Course title already exists");

            var newUser = createUserDTO.MapOne<User>();
            userRepo.Add(newUser);
            await userRepo.SaveChanges();

            return true;
            }
            catch (DbUpdateException ex)
            {
                // 🔴 REAL DATABASE ERROR HERE
                var dbMessage = ex.InnerException?.Message;

                throw new ApplicationException(dbMessage ?? "Database error occurred");
            }
            
        }
        
        public IEnumerable<GetUsersDTO> GetUsers()
        {
            return userRepo.GetAll().Map<GetUsersDTO>();
        }


    }
}