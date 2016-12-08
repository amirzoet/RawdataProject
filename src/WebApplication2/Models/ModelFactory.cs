using Microsoft.AspNetCore.Mvc;
using RDProject.Domain_model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Models
{
    public class ModelFactory
    {
        public static User Map(UserModel model)
        {
            return new User
            {
                name = model.name,
                creationdate = model.creationdate,
                age = model.age,
                location = model.location
            };
        }

        public static UserModel Map(User user, IUrlHelper URL)
        {
            return new UserModel
            {
                url = URL.Link(Config.UserRoute, new { id = user.id  }),
                name = user.name,
                creationdate = user.creationdate,
                age = user.age,
                location = user.location,
            };
        }

    }
}
