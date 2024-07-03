using System;
using System.Collections.Generic;

namespace DataAccess.DBModels;

public partial class Language
{
    public int Languageid { get; set; }

    public string Languagecode { get; set; } = null!;

    public string Languagename { get; set; } = null!;

    public DateTime Creationdate { get; set; }

    public DateTime? Updatedate { get; set; }

    public virtual ICollection<Article> Articles { get; set; } = new List<Article>();

    public virtual ICollection<Topic> Topics { get; set; } = new List<Topic>();
}
