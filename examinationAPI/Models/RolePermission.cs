using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using examinationAPI.Models.Enums;

namespace examinationAPI.Models
{
    public class RolePermission : BaseModel
    {
        public int Permission { get; set; }
        public Permission Permissions { get; set; }
        public int RoleId { get; set; }
        public Role Role { get; set; }
    }
}