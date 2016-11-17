using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RDProject.Domain_model
{
    public class Search
    {
        [Key]
        public int id { get; set; }
        public DateTime timestamp { get; set; }
        public string text { get; set; }
    }
}
