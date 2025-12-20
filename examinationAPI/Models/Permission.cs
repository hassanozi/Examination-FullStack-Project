using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace examinationAPI.Models
{
    public class Permission : BaseModel
    {
        public string Title { get; set; }

        public HashSet<RolePermission> RolePermissions { get; set; }
    }
}