using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication.Controllers
{
    [Route("api/users")]
    public class UserController
    {
        [HttpGet]
        public IActionResult getUser(int id)
        {
            return Ok();
        }
    }
}
