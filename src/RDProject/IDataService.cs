using RDProject.Domain_model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RDProject
{
    public interface IDataService
    {
        IList<Post> GetPosts();
    }
}
