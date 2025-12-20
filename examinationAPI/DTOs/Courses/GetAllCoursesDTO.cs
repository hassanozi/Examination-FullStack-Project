using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace examinationAPI.DTOs.Courses
{
    public class GetAllCoursesDTO
    {
        public int CourseId { get; set;}
        public required string Title { get; set; }
        public required string Description { get; set; }
        public int creditHours { get; set; }
        public string? PreRequisetTitle { get; set; }

        // public GetInstructorInfoDTO? Instructors { get; set; }
    }
}