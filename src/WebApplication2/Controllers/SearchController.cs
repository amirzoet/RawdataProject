using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RDProject;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    [Route("api/myusers/{myuser}")]  
    public class SearchController : BaseController
    {
        public SearchController(IDataService dataService) : base(dataService)
        {
        }

        [HttpGet("")]
        public IActionResult Get(int myuser, string search , int page=1)
        {
            var searchresults = DataService.Search(search, myuser, page, Config.DefaultPageSize).ToList();
            return Ok(ModelFactory.Map(searchresults));
        }
    }
}
