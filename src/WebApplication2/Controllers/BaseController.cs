using Microsoft.AspNetCore.Mvc;
using RDProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Controllers
{
    public class BaseController : Controller
    {
        public IDataService DataService { get; }

        public BaseController(IDataService dataService)
        {
            DataService = dataService;
        }
        

        //protected string getNextUrl(IUrlHelper URL, string route , int page, int pagesize)
        //{
        //    return URL.Link(route, new { page = page +1 });
        //}
        
    }
}
