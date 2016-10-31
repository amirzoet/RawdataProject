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
                var users = db.users.Where(u =>u.age>40);

                
                foreach (var user in users)
                {
                    Console.WriteLine($"{user.name} {user.age}");
                }
            }
        }
    }
}
