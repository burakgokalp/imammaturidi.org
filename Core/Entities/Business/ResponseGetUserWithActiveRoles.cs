using System;
using System.Collections.Generic;

namespace Core.Entities.Business;

public class ResponseGetUserWithActiveRoles
{
    public int Userid { get; set; }

    public string Username { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Passwordhash { get; set; } = null!;

    public DateTime Creationdate { get; set; }

    public DateTime? Updatedate { get; set; }


    public List<BRole> Roles { get; set; } = new List<BRole>();
}

public class BRole
{
    public int Roleid { get; set; }

    public string Rolename { get; set; } = null!;

    public DateTime Creationdate { get; set; }

    public DateTime? Updatedate { get; set; }
}