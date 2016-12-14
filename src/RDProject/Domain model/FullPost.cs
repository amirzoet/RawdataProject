using RDProject.Domain_model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RDProject.Domain_model
{
    public class FullPost
    {
        public Question question { get; set; }
        public List<string> tags { get; set; }
        public List<Answer> answers { get; set; }
        public List<Comment> comments { get; set; }
    }
}
