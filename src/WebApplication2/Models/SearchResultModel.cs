using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication2.Models
{
    public class SearchResultModel
    {
        public int score { get; set; }
        public string title { get; set; }
        public List<string> tags { get; set; }
        public string username { get; set; }
    }
}
