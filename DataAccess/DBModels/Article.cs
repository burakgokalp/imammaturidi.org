using System;
using System.Collections.Generic;

namespace DataAccess.DBModels;

public partial class Article
{
    public int Articleid { get; set; }

    public int Languageid { get; set; }

    public int Userid { get; set; }

    public int? Parentarticleid { get; set; }

    public int? Relatedarticleid { get; set; }

    public string Questiontext { get; set; } = null!;

    public string Answertext { get; set; } = null!;

    public DateTime Creationdate { get; set; }

    public DateTime? Updatedate { get; set; }

    public virtual ICollection<Articletopic> Articletopics { get; set; } = new List<Articletopic>();

    public virtual ICollection<Article> InverseParentarticle { get; set; } = new List<Article>();

    public virtual ICollection<Article> InverseRelatedarticle { get; set; } = new List<Article>();

    public virtual Language Language { get; set; } = null!;

    public virtual Article? Parentarticle { get; set; }

    public virtual Article? Relatedarticle { get; set; }

    public virtual User User { get; set; } = null!;
}
