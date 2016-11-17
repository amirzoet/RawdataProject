using Microsoft.EntityFrameworkCore;
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
            var user = ds.GetUser(1);
            //var search = ds.Search("java banana hashmap", 1, 1, 10);
            var comments = ds.GetCommentsToPost(19);
            var answers = ds.GetAnswersToQuestion(19);
            var searchhistory = ds.GetSearchHistory(1, 1, 10);
            var markhistory = ds.GetMarks(1, 1, 10);

            foreach (var item in markhistory)
            {
                Console.WriteLine($" {item.title},{item.mark}");
            }


            //Console.WriteLine("id, score, username, tags, title");
            //foreach (var item in search)
            //{
            //    string tags = "";
            //    foreach (string thing in item.tags)
            //    {
            //        tags += " " + thing;
            //    }
            //    Console.WriteLine($"{item.id}, {item.score}, {item.username}, {tags}, {item.title}");
            //}
        }
    }
}
  