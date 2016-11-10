﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RDProject.Domain_model
{
    public class SearchResult
    {
        public int id { get; set; }
        public int score { get; set; }
        public string title { get; set; }
        public List<string> tags { get; set; }
        public string username { get; set; }
    }
}
