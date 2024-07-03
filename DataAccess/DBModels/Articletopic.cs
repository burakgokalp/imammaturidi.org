using System;
using System.Collections.Generic;

namespace DataAccess.DBModels;

public partial class Articletopic
{
    public int Articletopicid { get; set; }

    public int Articleid { get; set; }

    public int Topicid { get; set; }

    public int? Ordernumber { get; set; }

    public DateTime Creationdate { get; set; }

    public DateTime? Updatedate { get; set; }

    public virtual Article Article { get; set; } = null!;

    public virtual Topic Topic { get; set; } = null!;
}
