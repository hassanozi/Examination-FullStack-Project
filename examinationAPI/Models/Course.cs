using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace examinationAPI.Models
{
    public class Course : BaseModel
    {
        public required string Title { get; set; }
        public required string Description { get; set; }
        public int creditHours { get; set; }

        public int? PrerequisiteCourseId { get; set; }
        public Course? PrerequisiteCourse { get; set; }
        public ICollection<Course> DependentCourses { get; set; } = new List<Course>();

        public HashSet<UserCourse>? UserCourses { get; set; }
        public HashSet<Exam>? Exams { get; set; }
        
    }
}