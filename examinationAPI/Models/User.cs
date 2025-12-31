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

        public string FullName => $"{FirstName} {LastName}";

        public required string UserName { get; set; }
        public required string Email { get; set; }
        public required string PasswordHash { get; set; }

        // 🔥 Global system permission
        public SystemRole SystemRole { get; set; }

        // Many-to-many: user <-> groups
    public HashSet<UserGroup> UserGroups { get; set; }

    // Many-to-many: user <-> exams
    public HashSet<UserExam> UserExams { get; set; }

    // Many-to-many: user <-> courses
    public HashSet<UserCourse> UserCourses { get; set; }
    }

}