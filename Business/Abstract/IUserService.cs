using Core.Entities.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IUserService
    {
        Task<UserInfoDTO> AuthenticateUser(string email, string password);

        /// <summary>
        /// get user by username and password.
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns>returns null if not found else returns with list of Roles <seealso cref="BRole"/></returns>
        Task<ResponseGetUserWithActiveRoles> GetUserWithActiveRolesAsync(string userName,  string password);
        /// <summary>
        /// get user by userId.
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns>returns null if not found else returns with list of Roles <seealso cref="BRole"/></returns>
        Task<ResponseGetUserWithActiveRoles> GetUserWithActiveRolesAsync(int userId);
    }
}
