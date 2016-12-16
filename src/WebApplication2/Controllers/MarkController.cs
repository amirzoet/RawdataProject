using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RDProject;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    [Route("api/myusers/{userid}/marks")]
    public class MarkController : BaseController
    {
        public MarkController(IDataService dataService) : base(dataService)
        {
        }

        [HttpGet("", Name = Config.MarkRoute)]
        public IActionResult Get(int userid, int page=1)


        {
            var marks = DataService.GetMarks(userid, page, Config.DefaultPageSize).ToList();
            if (marks == null) return NotFound();
            List<MarkModel> markmodels = new List<MarkModel>();
            foreach (var mark in marks)
            {
                markmodels.Add(ModelFactory.Map(mark, Url));
            }
            var result = new
            {
                url = Url.Link(Config.MarkRoute, new { userid, page }),
                data = markmodels
            };

            return Ok(markmodels);
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
