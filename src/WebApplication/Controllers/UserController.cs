using Microsoft.AspNetCore.Mvc;
using RDProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Controllers
{
    [Route("api/users")]
    public class UserController : BaseController
    {
        public UserController(IDataService dataservice) : base(dataservice)
        {
        }

        [HttpGet("{id}", Name = Config.UserRoute)]
        public IActionResult Get(int id)
        {
            var user = DataService.GetUser(id);
            if (user == null) return NotFound();
            return Ok(new { user.name, user.creationdate, user.location, user.age });
        }
    }
}
