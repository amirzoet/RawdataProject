using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RDProject.Domain_model;

namespace RDProject
{
    public class DataService : IDataService
    {
        public IList<Post> GetPosts()
        {
            using (var db = new DatabaseContext())
            {
                return db.posts.ToList();
            }
        
        }

        public IList<User> GetUsers()
        {
            using (var db = new DatabaseContext())
            {
                return db.users.ToList();
            }

        }
    }
}
