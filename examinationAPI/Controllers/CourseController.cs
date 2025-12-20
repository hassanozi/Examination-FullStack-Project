using System.Linq.Expressions;
using AutoMapper;
using examinationAPI.DTOs.Courses;
using examinationAPI.Models;
using examinationAPI.Services;
using examinationAPI.ViewModels;
using examinationAPI.ViewModels.Courses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PredicateExtensions;

namespace examinationAPI.Controllers
{
    [ApiController]
    [Route("[controller]/[Action]")]
    public class CourseController(CourseService serv, IMapper mapper) : ControllerBase
    {

        [HttpGet]
        // [Authorize]
        public ResponseViewModel<IEnumerable<GetAllCoursesViewModel>> GetAllCourses(string? orderBy = "Title", bool desc = false)
        {
            // var predicate = serv.MyPredicateBuilder(courseid, courseName, courseHourse);
            var query = serv.GetAllCourses(orderBy, desc);

            var coursesViewModel = mapper.Map<IEnumerable<GetAllCoursesViewModel>>(query);

            // var courses = new List<GetAllCoursesViewModel>();
            // foreach (var item in query)
            // {
            //     courses.Add(new GetAllCoursesViewModel
            //     {
            //         Title = item.Title,
            //         Description = item.Description,
            //         creditHours = item.creditHours,

            //         Instructor = new GetInstructorInfoViewModel()
            //         {
            //             FirstName = item.Instructor.FirstName,
            //             SecondName = item.Instructor.SecondName,
            //         }
            //     });
            // }

            // var coursesViewModel = mapper.Map<List<GetAllCoursesViewModel>>(coursesDto);

            return new SuccessResponseViewModel<IEnumerable<GetAllCoursesViewModel>>(coursesViewModel) ;
        }

        [HttpGet]
        public GetCourseViewModel Get(int? courseid , string? courseName ,int? courseHourse)
        {
            // var predicate = serv.MyPredicateBuilder(courseid, courseName, courseHourse);
            var query = serv.GetCourse(courseid, courseName, courseHourse);

            return mapper.Map<GetCourseViewModel>(query);
        }

        [HttpPost]
        public async Task<bool> Add(AddCourseViewModel course)
        {
            var crs = new AddCourseDTO()
            {
                Title = course.Title,
                Description = course.Description,
                creditHours = course.creditHours
            };

            return await serv.Add(crs);
        }

        [HttpPost]
        public async Task<bool> AddPreRequisetCourse(AddPreRequisetCourseViewModel preRequisetCourse)
        {
            var preRequisetCourseDTO = mapper.Map<AddPreRequisetCourseDTO>(preRequisetCourse);
            return await serv.AddPreRequisetCourse(preRequisetCourseDTO);
        }

        [HttpPost]
        public bool update(Course course)
        {
            return serv.update(course);
        }
        // [HttpPost]
        // public bool AssignExamToCourse(int courseId, int examId)
        // {
        //     serv.AssignExamToCourse(courseId, examId);
        //     return true;
        // }
    }
}