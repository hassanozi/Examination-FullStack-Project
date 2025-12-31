using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using examinationAPI.Models.Enums;

namespace examinationAPI.Models
{
    public class UserCourse : BaseModel
    {
        public int UserId { get; set; }
        public User User { get; set; }

        public int CourseId { get; set; }
        public Course Course { get; set; }

        public CourseRole Role { get; set; }

        public DateTime EnrolledAt { get; set; }
        public double? FinalGrade { get; set; }
    }


}