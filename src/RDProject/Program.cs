﻿using Microsoft.EntityFrameworkCore;
using RDProject.Domain_model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RDProject
{
    public class Program
    {
        public static void Main(string[] args)
        {
            DataService ds = new DataService();
            var posts = ds.GetPosts(p => p.score>10, 1, 1);
            var users = ds.GetUsers(u => true, 1, 1);
            var search = ds.Search("java banana hashmap", 1, 1, 10);

            foreach (var item in search.Take(20))
            {
                Console.WriteLine($"{item.id}, {item.ranking}");
            }
        }
    }
}
  