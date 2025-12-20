using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using examinationAPI.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace examinationAPI.Controllers
{
    [ApiController]
    [Route("[controller]/[Action]")]
    public class LoginController : ControllerBase
    {
        [HttpPost]
        public ActionResult Login(string UserName, string Password)
        {
            var token = GenerateToken.Generate("Hassano", "Hassan","Admin");

            return Ok(new {Token=token});
        }
    }
}