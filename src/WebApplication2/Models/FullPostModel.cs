using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication2.Models
{
    public class FullPostModel
    {
        public string url { get; set; }
        public QuestionModel questionmodel { get; set; }
        public List<string> tags { get; set; }
        public List<AnswerModel> answermodels { get; set; }
    }
}
