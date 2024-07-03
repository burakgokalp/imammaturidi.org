using System;
using System.Collections.Generic;

namespace DataAccess.DBModels;

public partial class Userrole
{
    public int Userroleid { get; set; }

    public int Userid { get; set; }

    public int Roleid { get; set; }

    public DateTime Creationdate { get; set; }

    public DateTime? Updatedate { get; set; }

    public virtual Role Role { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
