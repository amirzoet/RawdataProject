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
            using(var db = new DatabaseContext())
            {
                var posts = db.posts;

                foreach (var post in posts)
                {
                    Console.WriteLine($"{post.id} {post.score}");
                }
            }
        }
    }
}
