using DataAccess.DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public interface IUsersDAL
    {
        User GetUserInfo(string Username, string Password);
        User GetUserInfo(int Userid);

        User SaveUser(User user);
        bool DeleteUser(int Userid);
        User UpdateUser(User user);
    }
}
