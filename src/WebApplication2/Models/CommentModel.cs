using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication2.Models
{
    public class CommentModel
    {
        public DateTime creationdate { get; set; }
        public string body { get; set; }
        public int score { get; set; }
        public string username { get; set; }
        public string userurl { get; set; }
    }
}
