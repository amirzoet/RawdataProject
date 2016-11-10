using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RDProject.Domain_model
{
    public class SearchId
    {   
        [Key]
        public int questionid { get; set; }
        public int ranking { get; set; }
    }
}
