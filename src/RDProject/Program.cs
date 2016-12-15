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
            var search = ds.Search("java banana hashmap",1,1,10);

            var sh = ds.GetSearchHistory(1,1,100);

            //var answers = ds.GetAnswersToQuestion(19);
            //var searchhistory = ds.GetSearchHistory(1, 1, 10);           
            //Console.WriteLine(ds.Mark(1, 19, "useful mark"));
            //Console.WriteLine(ds.DeleteMark(1,19));
            //var markhistory = ds.GetMarks(1, 1, 10);
            //foreach (var item in markhistory)
            //{
            //    Console.WriteLine($" {item.postid},{item.mark}");
            //}
            //Console.WriteLine("id, score, username, tags, title");

            foreach (var item in sh)
            {
                Console.WriteLine($"{item.text},{item.timestamp}");
            }

            foreach (var item in search)
            {
                string tags = "";
                foreach (string thing in item.tags)
                {
                    tags += " " + thing;
                }
                Console.WriteLine($"{item.id}, {item.score}, {item.username}, {tags}, {item.title}");
            }
        }
    }
}
  