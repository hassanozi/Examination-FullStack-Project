using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace examinationAPI.ViewModels.Courses
{
    public class GetCourseViewModel
    {
        public int CourseId { get; set;}
        public required string Title { get; set; }
    }
}