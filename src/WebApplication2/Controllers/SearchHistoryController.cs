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
    [Route("api/myusers/{userid}/searchhistory")]
    public class SearchHistoryController : BaseController
    {
        public SearchHistoryController(IDataService dataService) : base(dataService)
        {
        }

        [Route("{page}", Name = Config.SearchHistoryRoute)]
        public IActionResult Get(int userid, int page)
        {
            var searchhistory = DataService.GetSearchHistory(userid, page, Config.DefaultPageSize).ToList();
            if (searchhistory == null) return NotFound();
            List<SearchModel> searchmodels = new List<SearchModel>();
            foreach (var search in searchhistory)
            {
                searchmodels.Add(ModelFactory.Map(search));
            }

            return Ok(searchmodels);
        }

    }
}
