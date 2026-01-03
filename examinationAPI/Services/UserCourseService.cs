using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using examinationAPI.DTOs.Courses;
using examinationAPI.DTOs.Users;
using examinationAPI.Helpers;
using examinationAPI.Models;
using examinationAPI.Models.Enums;
using examinationAPI.Repositories;

namespace examinationAPI.Services
{
    public class UserCourseService
    {
        private readonly IRepository<User> _userRepo;
        private readonly IRepository<Course> _courseRepo;
        private readonly IRepository<UserCourse> _userCourseRepo;

        public UserCourseService(
            IRepository<User> userRepo,
            IRepository<Course> courseRepo,
            IRepository<UserCourse> userCourseRepo)
        {
            _userRepo = userRepo;
            _courseRepo = courseRepo;
            _userCourseRepo = userCourseRepo;
        }

        public async Task EnrollStudent(int studentId, int courseId)
        {
            var user = await _userRepo.GetById(studentId);
            if (user == null || user.SystemRole != SystemRole.Student)
                throw new UnauthorizedAccessException("Only students can enroll");

            var course = await _courseRepo.GetById(courseId);
            if (course == null)
                throw new Exception("Course not found");

            bool alreadyEnrolled = _userCourseRepo.GetAll()
                .Any(uc => uc.UserId == studentId && uc.CourseId == courseId);

            if (alreadyEnrolled)
                throw new Exception("Student already enrolled");

            _userCourseRepo.Add(new UserCourse
            {
                UserId = studentId,
                CourseId = courseId,
                EnrolledAt = DateTime.UtcNow
            });

            await _userCourseRepo.SaveChanges();
        }
        public async Task UnenrollStudent(int studentId, int courseId)
        {
            var userCourse = _userCourseRepo.GetAll()
                .FirstOrDefault(uc => uc.UserId == studentId && uc.CourseId == courseId);

            if (userCourse == null)
                throw new Exception("Enrollment not found");

            _userCourseRepo.SoftDelete(userCourse);
            await _userCourseRepo.SaveChanges();
        }

        // 🔹 Get all courses a user is assigned to (student or instructor)
        public async Task<IEnumerable<GetCourseDTO>> GetUserCourses(int userId)
        {
            var user = await _userRepo.GetById(userId);
            if (user == null)
                throw new Exception("User not found");

            var courseDtos = _userCourseRepo.GetAll()
                .Where(uc => uc.UserId == userId)
                .Select(uc => uc.Course)
                .Map<GetCourseDTO>()  
                .ToList();           

            return courseDtos;
        }


        public IEnumerable<GetUsersDTO> GetCourseStudents(int courseId)
        {
            var course = _courseRepo.GetById(courseId).Result;
            if (course == null)
                throw new Exception("Course not found");

            var students = _userCourseRepo.GetAll()
                .Where(uc => uc.CourseId == courseId && uc.User.SystemRole == SystemRole.Student)
                .Select(uc => uc.User)
                .Map<GetUsersDTO>();

            return students;
        }

        public async Task AssignInstructor(int instructorId, int courseId)
        {
            var user = await _userRepo.GetById(instructorId);
            if (user == null || user.SystemRole != SystemRole.Instructor)
                throw new UnauthorizedAccessException("Only instructors can be assigned");

            var course = await _courseRepo.GetById(courseId);
            if (course == null)
                throw new Exception("Course not found");

            bool alreadyAssigned = _userCourseRepo.GetAll()
                .Any(uc => uc.UserId == instructorId && uc.CourseId == courseId);

            if (alreadyAssigned)
                throw new Exception("Instructor already assigned");

            _userCourseRepo.Add(new UserCourse
            {
                UserId = instructorId,
                CourseId = courseId,
                AssignedAt = DateTime.UtcNow
            });

            await _userCourseRepo.SaveChanges();
        }

     
        public async Task RemoveInstructor(int instructorId, int courseId)
        {
            var userCourse = _userCourseRepo.GetAll()
                .FirstOrDefault(uc => uc.UserId == instructorId && uc.CourseId == courseId);

            if (userCourse == null)
                throw new Exception("Assignment not found");

            _userCourseRepo.SoftDelete(userCourse);
            await _userCourseRepo.SaveChanges();
        }
    }
}