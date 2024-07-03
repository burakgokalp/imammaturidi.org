using System;
using System.Collections.Generic;

namespace DataAccess.DBModels;

public partial class Topic
{
    public int Topicid { get; set; }

    public int? Parenttopicid { get; set; }

    public int? Relatedtopicid { get; set; }

    public int Languageid { get; set; }

    public string Topicname { get; set; } = null!;

    public DateTime Creationdate { get; set; }

    public DateTime? Updatedate { get; set; }

    public virtual ICollection<Articletopic> Articletopics { get; set; } = new List<Articletopic>();

    public virtual ICollection<Topic> InverseParenttopic { get; set; } = new List<Topic>();

    public virtual ICollection<Topic> InverseRelatedtopic { get; set; } = new List<Topic>();

    public virtual Language Language { get; set; } = null!;

    public virtual Topic? Parenttopic { get; set; }

    public virtual Topic? Relatedtopic { get; set; }
}
