using DataAccess.DBModels;
using DataAccess.EF;
using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    public class UsersDAL : IUsersDAL
    {
        private readonly QaDbContext _dB;

        public UsersDAL(EF.QaDbContext DB)
        {
            _dB = DB;
        }
        public async Task<User> GetUserWithActiveRolesAsync(int UserId)
        {
            return await GetUserWithActiveRolesAsync(new User() { Userid = UserId });
        }
        public async Task<User> GetUserWithActiveRolesAsync(User user)
        {
            return await _dB.Users.Where(u => u.Userid == user.Userid).Include(u => u.Userroles).ThenInclude(ur => ur.Role).FirstOrDefaultAsync();
        }

    }
}