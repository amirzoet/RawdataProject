using RDProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RDProject.Controllers
{
    public class PostController
    {
        private readonly IDataService _dataservice;

        public PostController(IDataService dataservice)
        {
            _dataservice = dataservice;
        }
    }
}
