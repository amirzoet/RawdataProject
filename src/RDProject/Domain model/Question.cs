using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RDProject.Domain_model
{
    public class Question : Post
    {
        public string title { get; set; }
        public int acceptedanswerid { get; set; }
    }
}
