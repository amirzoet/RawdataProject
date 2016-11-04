using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RDProject.Domain_model;

namespace RDProject
{
    public class DataService : IDataService
    {
        public IList<Post> GetPosts(Func<Post,bool> predicate, int page, int pagesize)
        {
            using (var db = new DatabaseContext())
            {
                return db.posts.Where(predicate).ToList();
            }
        }

        public IList<User> GetUsers(Func<User, bool> predicate, int page, int pagesize)
        {
            using (var db = new DatabaseContext())
            {
                return db.users.Where(predicate).ToList();
            }
        }

        public IList<SearchResult> Search(string search, int userid, int page, int pagesize)
        {
            using (var db = new DatabaseContext())
            {
                return db.Set<SearchResult>().FromSql("call mysearch({0},{1},{2},{3})", new object[] {search, userid, page, pagesize}).ToList();
            }
        }
    }
}
