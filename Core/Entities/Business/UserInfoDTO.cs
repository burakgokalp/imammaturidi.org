using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.Business
{
    public class UserInfoDTO
    {
        public int Userid { get; set; }

        public string Username { get; set; } = null!;

        public string Email { get; set; } = null!;

        public List<string> Roles { get; set; }
       
    }
}
