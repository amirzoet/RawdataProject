using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RDProject.Domain_model
{
    public class User
    {
        public int id { get; set; }
        public string name { get; set; }
        public DateTime creationdate { get; set; }
        public string location { get; set; }
        public int? age { get; set; }
    }
}
