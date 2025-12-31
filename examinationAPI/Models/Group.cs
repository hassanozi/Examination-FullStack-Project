using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace examinationAPI.Models
{
    public class Group : BaseModel
    {
        public required string Name { get; set; }
        public HashSet<UserGroup> UserGroups { get; set; } = new(); // Users in the group
        public HashSet<GroupExam> GroupExams { get; set; } = new(); // Exams assigned to the group
    }



}