﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RDProject.Domain_model
{
    public class Question
    {
        public int id { get; set; }
        public DateTime creationdate { get; set; }
        public string body { get; set; }
        public int score { get; set; }
        public string title { get; set; }
        public int acceptedanswerid { get; set; }
        public int userid { get; set; }
        public int postid { get; set; }
    }
}
