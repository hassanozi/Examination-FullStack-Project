using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using examinationAPI.DTOs.Courses;
using examinationAPI.Helpers;
using examinationAPI.Models;
using examinationAPI.Repositories;
using examinationAPI.ViewModels;
using PredicateExtensions;

namespace examinationAPI.Services
{
    public class CourseService(IRepository<Course> Courserepo, IMapper mapper)
    {
        public async Task<bool>  Add(AddCourseDTO course)
        {
            var exists = await Courserepo
                .Get(c => c.Title == course.Title) != null;
               

            if (exists)
                throw new Exception("Course title already exists");

            var newCourse = new Course()
            {
                Title = course.Title,
                Description = course.Description,
                creditHours = course.creditHours
            };

            Courserepo.Add(newCourse);
            await Courserepo.SaveChanges();
            return true;
        }

        public async Task<bool> AddPreRequisetCourse (AddPreRequisetCourseDTO preRequisetCourse)
        {
           var newPreRequisetCourse = preRequisetCourse.MapOne<Course>();
           Courserepo.Add(newPreRequisetCourse); 
           await Courserepo.SaveChanges();

            return true;
        }

        public async Task<bool> Update(UpdateCourseDTO updateCourseDTO)
        {
            var course = await Courserepo.GetWithTrackingById(updateCourseDTO.CourseId);

            if (course == null)
                return false;
            
            updateCourseDTO.MapTo(course); 

            await Courserepo.SaveChanges();
            return true;
        }


        public IEnumerable<GetAllCoursesDTO> GetAllCourses(string? orderBy = null, bool desc = false)
        {
            var courses = Courserepo.GetAll().Map<GetAllCoursesDTO>();
            // .Select(c => new GetAllCoursesDTO
            // {
            //     CourseId = c.Id,
            //     Title = c.Title,
            //     Description = c.Description,
            //     creditHours = c.creditHours,
            //     PreRequisetTitle = c.PrerequisiteCourse != null
            //     ? c.PrerequisiteCourse.Title
            //     : null,

            //     // Instructors = c.InstructorCourses
            //     //     .Select(ci => new GetInstructorInfoDTO
            //     //     {
            //     //         FirstName = ci.Instructors.FirstName,
            //     //         SecondName = ci.Instructors.SecondName,
            //     //     }).FirstOrDefault()
            // });

            if (!string.IsNullOrEmpty(orderBy))
            {
                switch (orderBy.ToLower())
                {
                    case "title":
                        courses = desc ? courses.OrderByDescending(c => c.Title) : courses.OrderBy(c => c.Title);
                        break;
                    case "credithours":
                        courses = desc ? courses.OrderByDescending(c => c.creditHours) : courses.OrderBy(c => c.creditHours);
                        break;
                    default:
                        courses = courses.OrderBy(c => c.Title);
                        break;
                }
            }

            /// var query = Courserepo.GetAll().ToList();

            /// if (courseHourse != null)
            ///     res = res.Where(x => x.creditHours == courseHourse).ToList();
            /// if (!string.IsNullOrEmpty(courseName))
            ///     res = res.Where(c => c.Title == courseName).ToList();
            /// var query = Courserepo.GetAll();

            /// var crc = query.Select(c => new GetAllCoursesDTO
            /// {
            ///     Title = c.Title,
            ///     Description = c.Description,
            ///     creditHours = c.creditHours,

            ///     Instructor = new DTOs.Instructor.GetInstructorInfoDTO
            ///     {
            ///         FirstName = c.InstructorCourses.Select(s => s.Instructors.FirstName).FirstOrDefault(),
            ///         SecondName = c.InstructorCourses.Select(s => s.Instructors.SecondName).FirstOrDefault(),
            ///     }
            /// });

            /// var query = Courserepo.GetAll().ProjectTo<GetAllCoursesDTO>(mapper.ConfigurationProvider).ToList();

            return courses;
        }

        private bool IsCourseExist(int id)
        {
            var res = Courserepo.Exists(id);
            return res;
        }

        // private bool IsExamExist(int id)
        // {
        //     var res = examRepo.Exists(id);
        //     return res;
        // }

        // public void AssignExamToCourse(int courseId, int examId)
        // {
        //     if (!IsCourseExist(courseId))
        //         throw new Exception("Course Not Found");
        //     if (!IsExamExist(examId))
        //         throw new Exception("Exam Not Found");

            
        // }

        private Expression<Func<Course, bool>> MyPredicateBuilder(int? coursid, string? courseName, int? courseHours)
        {
            var predicate = PredicateExtensions.PredicateExtensions.Begin<Course>(true);

            if (coursid.HasValue)
                predicate = predicate.And(c => c.Id == coursid);
            if (courseHours.HasValue)
                predicate = predicate.And(c => c.creditHours == courseHours);
            if (!string.IsNullOrEmpty(courseName))
                predicate = predicate.And(c => c.Title == courseName);

            return predicate;
        }
        
        public async Task<GetCourseDTO> GetCourse (int? courseid , string? courseName ,int? courseHourse)
        {
            var predicate = MyPredicateBuilder(courseid, courseName, courseHourse);
            var course = await Courserepo.Get(predicate);
            return course.MapOne<GetCourseDTO>();
        }

        public  async Task<bool> DeleteCourse(int courseId)
        {
            var course = await Courserepo.Get(c => c.Id == courseId);
            if (course == null)
                throw new Exception("Course Not Found");

            Courserepo.SoftDelete(course);
            await Courserepo.SaveChanges();
            return true;
        }
    }
}