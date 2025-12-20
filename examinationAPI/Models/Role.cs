using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace examinationAPI.Models
{
    public class Role : BaseModel
    {
        public required string RoleName { get; set; }

        public HashSet<User> Users { get; set; } 
    }
}