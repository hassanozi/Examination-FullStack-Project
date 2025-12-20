using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace examinationAPI.Models
{
    public class UserCourse : BaseModel
    {
        public int UserId { get; set; }
        public required User User{ get; set; }
        public int CourseId { get; set; }
        public required Course Course { get; set; }
    }
}