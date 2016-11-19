using Microsoft.AspNetCore.Mvc;
using RDProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Controllers
{
    public class BaseController : Controller
    {
        public IDataService DataService { get; }

        public BaseController(IDataService dataService)
        {
            DataService = dataService;
        }
    
    }
}
