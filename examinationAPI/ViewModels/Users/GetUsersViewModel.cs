using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace examinationAPI.ViewModels.Users
{
    public class GetUsersViewModel
    {
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string UserName { get; set; }
        public required string Email { get; set; }
    }
}