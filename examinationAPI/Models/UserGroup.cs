using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace examinationAPI.Models
{
    public class UserGroup : BaseModel
    {
        public int UserId { get; set; }
        public required User User{ get; set; }
        public int GroupId { get; set; } 
        public required Group Group{ get; set; }
    }
}