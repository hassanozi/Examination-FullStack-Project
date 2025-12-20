using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace examinationAPI.ViewModels.Courses
{
    public class GetAllCoursesViewModel
    {
        public int CourseId { get; set;}
        public required string Title { get; set; }
        public required string Description { get; set; }
        public int creditHours { get; set; }
        public string? PreRequisetTitle { get; set; }


    }
}