using System;
using System.Collections.Generic;

namespace DataAccess.DBModels;

public partial class Role
{
    public int Roleid { get; set; }

    public string Rolename { get; set; } = null!;

    public DateTime Creationdate { get; set; }

    public DateTime? Updatedate { get; set; }

    public virtual ICollection<Userrole> Userroles { get; set; } = new List<Userrole>();
}
