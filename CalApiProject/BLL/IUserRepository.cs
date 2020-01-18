using CalApiProject.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalApiProject.BLL
{
    public interface IUserRepository : IDisposable
    {
        User ValidateUser(string name, string password);
    }
}
