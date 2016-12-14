using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RDProject.Domain_model
{
    public class Answer
    {
        public int id { get; set; }
        public DateTime creationdate { get; set; }
        public string body { get; set; }
        public int score { get; set; }
        public int userid { get; set; }
        public string username { get; set; }
        public int postid { get; set; }
        public int parentid { get; set; }
    }
}
