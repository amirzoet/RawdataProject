﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RDProject.Domain_model
{
    public class Comment : Post
    {
        public int parentid { get; set; }
    }
}
