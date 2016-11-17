using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RDProject.Domain_model
{
    public class Mark
    {
        public int postid { get; set; }
        public int userid { get; set; }
        public string title { get; set; }
        public string mark { get; set; }
    }
}
