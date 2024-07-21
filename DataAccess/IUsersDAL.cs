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
        /// <summary>
        /// Get user entity if exists
        /// </summary>
        /// <param name="user">get user by user.userid</param>
        /// <returns></returns>
        Task<User> GetUserWithActiveRolesAsync(User user);

        /// <summary>
        /// Get user by userid
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns>if exists returns User entity</returns>
        Task<User> GetUserWithActiveRolesAsync(int UserId);
    }
}
