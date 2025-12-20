using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace examinationAPI.DTOs.Courses
{
    public class AddPreRequisetCourseDTO
    {
        public required string Title { get; set; }
        public required string Description { get; set; }
        public int creditHours { get; set; }
        public int PrerequisiteCourseId { get; set; } = 0;
    }
}