using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace examinationAPI.Models
{
    public class Group : BaseModel
    {
        public required string GroupName { get; set; }
        public HashSet<UserGroup> UserGroups { get; set; }
    }
}