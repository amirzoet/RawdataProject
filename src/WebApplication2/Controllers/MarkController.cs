using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RDProject;
using WebApplication2;

namespace WebApplication2.Controllers
{
    [Route("api/myusers/{userid}/marks")]
    public class MarkController : BaseController
    {
        public MarkController(IDataService dataService) : base(dataService)
        {
        }
        [HttpGet("{page}")]
        public IActionResult Get(int userid, int page)
        {
            var marks = DataService.GetMarks(userid, page, Config.DefaultPageSize);
            if (marks == null) return NotFound();
            return Ok(marks);
        }

        [HttpDelete("{postid}")]
        public IActionResult Delete(int userid, int postid)
        {
            if (!DataService.DeleteMark(userid, postid))
            {
                return NotFound();
            }

            return Ok();
        }

    }
}
