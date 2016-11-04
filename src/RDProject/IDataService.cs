using RDProject.Domain_model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RDProject
{
    public interface IDataService
    {
        IList<Post> GetPosts(Func<Post, bool> predicate, int page, int pagesize);
        IList<User> GetUsers(Func<User, bool> predicate, int page, int pagesize);
        IList<SearchResult> Search(string search, int userid, int page, int pagesize);
    }
}
