using CalApiProject.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CalApiProject.BLL
{
    public class UserRepository : IUserRepository
    {
        private  UserMock mock;

        public UserRepository()
        {
            mock = new UserMock();
        }

        public UserRepository(UserMock userMock)
        {
            mock = new UserMock();
        }

        public User ValidateUser(string userName, string passWord)
        {
            var _user = from u in mock.GetUsers()
                        where u.Email.Equals(userName) && u.Password.Equals(passWord)
                        select u;
            return _user.FirstOrDefault();
        }

        public void Dispose()
        {
            mock = null;
        }

    }
}