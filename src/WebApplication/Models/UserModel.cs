using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Models
{
    public class UserModel
    {
        public string url { get; set; }
        public string name { get; set; }
        public DateTime creationdate { get; set; }
        public string location { get; set; }
        public int? age { get; set; }
    }
}
