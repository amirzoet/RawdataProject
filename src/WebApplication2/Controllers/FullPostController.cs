using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RDProject;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{

    [Route("api/posts")]
    public class FullPostController : BaseController
    {
        public FullPostController(IDataService dataService) : base(dataService)
        {
        }

        [HttpGet("{id:int}", Name = Config.PostRoute)]
        public IActionResult Get(int id)
        {
            var post = DataService.GetPost(id);
            if (post == null) return NotFound();


            return Ok(ModelFactory.Map(post, Url));
        }
    }
}
