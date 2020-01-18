using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CalApiProject.DAL
{
    public class UserMock
    {
        List<User> users;

        public UserMock()
        {
            users = new List<User> {
                new User { Name = "Nir", Email = "nir.fadel@gmail.com", Password = "pass", Role = "Admin", UserId = 1 },
                 new User { Name = "Roi", Email = "roi@gmail.com", Password = "pass", Role = "Admin", UserId = 2 },
                  new User { Name = "Dor", Email = "dor@gmail.com", Password = "pass", Role = "User", UserId = 3 },
                   new User { Name = "Itay", Email = "itay@gmail.com", Password = "pass", Role = "User", UserId = 4 },
                    new User { Name = "Ofer", Email = "ofer@gmail.com", Password = "pass", Role = "Admin", UserId = 5 }
            };
            


        }

        public List<User> GetUsers()
        {
            return users;
        }
                   
    }
}