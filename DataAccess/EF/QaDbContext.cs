using System;
using System.Collections.Generic;
using DataAccess.DBModels;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.EF;

public partial class QaDbContext : DbContext
{
    public QaDbContext(DbContextOptions<QaDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Article> Articles { get; set; }

    public virtual DbSet<Articletopic> Articletopics { get; set; }

    public virtual DbSet<Language> Languages { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Topic> Topics { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<Userlog> Userlogs { get; set; }

    public virtual DbSet<Userrole> Userroles { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Article>(entity =>
        {
            entity.HasKey(e => e.Articleid).HasName("articles_pkey");

            entity.ToTable("articles");

            entity.Property(e => e.Articleid).HasColumnName("articleid");
            entity.Property(e => e.Answertext).HasColumnName("answertext");
            entity.Property(e => e.Creationdate)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("creationdate");
            entity.Property(e => e.Languageid).HasColumnName("languageid");
            entity.Property(e => e.Parentarticleid).HasColumnName("parentarticleid");
            entity.Property(e => e.Questiontext).HasColumnName("questiontext");
            entity.Property(e => e.Relatedarticleid).HasColumnName("relatedarticleid");
            entity.Property(e => e.Updatedate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updatedate");
            entity.Property(e => e.Userid).HasColumnName("userid");

            entity.HasOne(d => d.Language).WithMany(p => p.Articles)
                .HasForeignKey(d => d.Languageid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("articles_languageid_fkey");

            entity.HasOne(d => d.Parentarticle).WithMany(p => p.InverseParentarticle)
                .HasForeignKey(d => d.Parentarticleid)
                .HasConstraintName("articles_parentarticleid_fkey");

            entity.HasOne(d => d.Relatedarticle).WithMany(p => p.InverseRelatedarticle)
                .HasForeignKey(d => d.Relatedarticleid)
                .HasConstraintName("articles_relatedarticleid_fkey");

            entity.HasOne(d => d.User).WithMany(p => p.Articles)
                .HasForeignKey(d => d.Userid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("articles_userid_fkey");
        });

        modelBuilder.Entity<Articletopic>(entity =>
        {
            entity.HasKey(e => e.Articletopicid).HasName("articletopics_pkey");

            entity.ToTable("articletopics");

            entity.HasIndex(e => new { e.Articleid, e.Topicid }, "articletopics_articleid_topicid_key").IsUnique();

            entity.Property(e => e.Articletopicid).HasColumnName("articletopicid");
            entity.Property(e => e.Articleid).HasColumnName("articleid");
            entity.Property(e => e.Creationdate)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("creationdate");
            entity.Property(e => e.Ordernumber)
                .HasDefaultValue(0)
                .HasColumnName("ordernumber");
            entity.Property(e => e.Topicid).HasColumnName("topicid");
            entity.Property(e => e.Updatedate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updatedate");

            entity.HasOne(d => d.Article).WithMany(p => p.Articletopics)
                .HasForeignKey(d => d.Articleid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("articletopics_articleid_fkey");

            entity.HasOne(d => d.Topic).WithMany(p => p.Articletopics)
                .HasForeignKey(d => d.Topicid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("articletopics_topicid_fkey");
        });

        modelBuilder.Entity<Language>(entity =>
        {
            entity.HasKey(e => e.Languageid).HasName("languages_pkey");

            entity.ToTable("languages");

            entity.Property(e => e.Languageid).HasColumnName("languageid");
            entity.Property(e => e.Creationdate)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("creationdate");
            entity.Property(e => e.Languagecode)
                .HasMaxLength(10)
                .HasColumnName("languagecode");
            entity.Property(e => e.Languagename)
                .HasMaxLength(100)
                .HasColumnName("languagename");
            entity.Property(e => e.Updatedate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updatedate");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Roleid).HasName("roles_pkey");

            entity.ToTable("roles");

            entity.Property(e => e.Roleid).HasColumnName("roleid");
            entity.Property(e => e.Creationdate)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("creationdate");
            entity.Property(e => e.Rolename)
                .HasMaxLength(50)
                .HasColumnName("rolename");
            entity.Property(e => e.Updatedate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updatedate");
        });

        modelBuilder.Entity<Topic>(entity =>
        {
            entity.HasKey(e => e.Topicid).HasName("topics_pkey");

            entity.ToTable("topics");

            entity.Property(e => e.Topicid).HasColumnName("topicid");
            entity.Property(e => e.Creationdate)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("creationdate");
            entity.Property(e => e.Languageid).HasColumnName("languageid");
            entity.Property(e => e.Parenttopicid).HasColumnName("parenttopicid");
            entity.Property(e => e.Relatedtopicid).HasColumnName("relatedtopicid");
            entity.Property(e => e.Topicname)
                .HasMaxLength(255)
                .HasColumnName("topicname");
            entity.Property(e => e.Updatedate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updatedate");

            entity.HasOne(d => d.Language).WithMany(p => p.Topics)
                .HasForeignKey(d => d.Languageid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("topics_languageid_fkey");

            entity.HasOne(d => d.Parenttopic).WithMany(p => p.InverseParenttopic)
                .HasForeignKey(d => d.Parenttopicid)
                .HasConstraintName("topics_parenttopicid_fkey");

            entity.HasOne(d => d.Relatedtopic).WithMany(p => p.InverseRelatedtopic)
                .HasForeignKey(d => d.Relatedtopicid)
                .HasConstraintName("topics_relatedtopicid_fkey");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Userid).HasName("users_pkey");

            entity.ToTable("users");

            entity.Property(e => e.Userid).HasColumnName("userid");
            entity.Property(e => e.Creationdate)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("creationdate");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .HasColumnName("email");
            entity.Property(e => e.Passwordhash)
                .HasMaxLength(255)
                .HasColumnName("passwordhash");
            entity.Property(e => e.Updatedate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updatedate");
            entity.Property(e => e.Username)
                .HasMaxLength(255)
                .HasColumnName("username");
        });

        modelBuilder.Entity<Userlog>(entity =>
        {
            entity.HasKey(e => e.Logid).HasName("userlogs_pkey");

            entity.ToTable("userlogs");

            entity.Property(e => e.Logid).HasColumnName("logid");
            entity.Property(e => e.Browsername)
                .HasMaxLength(100)
                .HasColumnName("browsername");
            entity.Property(e => e.Browserversion)
                .HasMaxLength(20)
                .HasColumnName("browserversion");
            entity.Property(e => e.Country)
                .HasMaxLength(100)
                .HasColumnName("country");
            entity.Property(e => e.Datetime)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("datetime");
            entity.Property(e => e.Httprequestmethod)
                .HasMaxLength(10)
                .HasColumnName("httprequestmethod");
            entity.Property(e => e.Httprequestquery).HasColumnName("httprequestquery");
            entity.Property(e => e.Refererurl)
                .HasMaxLength(2048)
                .HasColumnName("refererurl");
            entity.Property(e => e.Requestedurl)
                .HasMaxLength(2048)
                .HasColumnName("requestedurl");
            entity.Property(e => e.Responsetime).HasColumnName("responsetime");
            entity.Property(e => e.Statuscode).HasColumnName("statuscode");
            entity.Property(e => e.Useragent).HasColumnName("useragent");
            entity.Property(e => e.Userid).HasColumnName("userid");
            entity.Property(e => e.Userip)
                .HasMaxLength(64)
                .HasColumnName("userip");

            entity.HasOne(d => d.User).WithMany(p => p.Userlogs)
                .HasForeignKey(d => d.Userid)
                .HasConstraintName("userlogs_userid_fkey");
        });

        modelBuilder.Entity<Userrole>(entity =>
        {
            entity.HasKey(e => e.Userroleid).HasName("userroles_pkey");

            entity.ToTable("userroles");

            entity.HasIndex(e => new { e.Userid, e.Roleid }, "userroles_userid_roleid_key").IsUnique();

            entity.Property(e => e.Userroleid).HasColumnName("userroleid");
            entity.Property(e => e.Creationdate)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("creationdate");
            entity.Property(e => e.Roleid).HasColumnName("roleid");
            entity.Property(e => e.Updatedate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updatedate");
            entity.Property(e => e.Userid).HasColumnName("userid");

            entity.HasOne(d => d.Role).WithMany(p => p.Userroles)
                .HasForeignKey(d => d.Roleid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("userroles_roleid_fkey");

            entity.HasOne(d => d.User).WithMany(p => p.Userroles)
                .HasForeignKey(d => d.Userid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("userroles_userid_fkey");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
