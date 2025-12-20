using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using examinationAPI.Models.Enums;

namespace examinationAPI.Models
{
    public class User : BaseModel
    {
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public string fullName => $"{FirstName} {LastName}";
        public required string UserName { get; set; }
        public required string Email { get; set; }
        public required string PasswordHash { get; set; }

        public int RoleId { get; set; }
        public required Role Role { get; set; }
        public required HashSet<UserCourse> UserCourses { get; set; }
        public required HashSet<UserGroup> UserGroups { get; set; }
        public required HashSet<UserExam> UserExams { get; set; }

    }
}