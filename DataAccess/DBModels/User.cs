using System;
using System.Collections.Generic;

namespace DataAccess.DBModels;

public partial class User
{
    public int Userid { get; set; }

    public string Username { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Passwordhash { get; set; } = null!;

    public DateTime Creationdate { get; set; }

    public DateTime? Updatedate { get; set; }

    public virtual ICollection<Article> Articles { get; set; } = new List<Article>();

    public virtual ICollection<Userlog> Userlogs { get; set; } = new List<Userlog>();

    public virtual ICollection<Userrole> Userroles { get; set; } = new List<Userrole>();
}
