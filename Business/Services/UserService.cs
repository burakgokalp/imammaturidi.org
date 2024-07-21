using Business.Abstract;
using DataAccess.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Extensions;
using Microsoft.EntityFrameworkCore;
using DataAccess;
using Core.Entities.Business;

namespace Business.Services
{
    public class UserService : IUserService
    {
        private readonly QaDbContext _db;
        private readonly IUsersDAL _userDal;

        public UserService(QaDbContext db, IUsersDAL userDal)
        {
            this._db = db;
            _userDal = userDal;
        }

        public async Task<UserInfoDTO> AuthenticateUser(string email, string password)
        {
            return await _db.Users.Where(u => u.Email == email && u.Passwordhash == password.ExtToSha2Hash())
                .Include(u => u.Userroles)
                .ThenInclude(ur => ur.Role) // Rollerin yüklendiğinden emin olun
                .Select(u => new UserInfoDTO() { 
                    Username = u.Username, 
                    Email = u.Email, 
                    Userid = u.Userid, 
                    Roles = u.Userroles.Select(u => u.Role.Rolename).ToList()
                })
                .FirstOrDefaultAsync();
        }

        public async Task<ResponseGetUserWithActiveRoles> GetUserWithActiveRolesAsync(string userName, string password)
        {
            ResponseGetUserWithActiveRoles response = null;
            var userInDb = await _db.Users.Where(u => u.Username == userName.Trim() && u.Passwordhash == password.ExtToSha2Hash()).FirstOrDefaultAsync();
            if (userInDb != null)
            {
                response = await this.GetUserWithActiveRolesAsync(userInDb.Userid);
            }
            return response;
        }

        public async Task<ResponseGetUserWithActiveRoles> GetUserWithActiveRolesAsync(int userId)
        {
            ResponseGetUserWithActiveRoles response = null;
            var userInDb = await _db.Users.Where(u => u.Userid == userId).FirstOrDefaultAsync();
            if (userInDb != null)
            {
                var results = await _userDal.GetUserWithActiveRolesAsync(userInDb.Userid);
                response.Roles = results.Userroles.Select(ur => new BRole()
                {
                    Creationdate = ur.Role.Creationdate,
                    Roleid = ur.Roleid,
                    Rolename = ur.Role.Rolename,
                    Updatedate = ur.Role.Updatedate
                }).ToList();
            }
            return response;
        }
    }
}
