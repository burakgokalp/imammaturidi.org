using System;
using System.Collections.Generic;
using DataAccess.DBModels;
using Microsoft.EntityFrameworkCore;
using static System.Collections.Specialized.BitVector32;

namespace DataAccess.EF;

public partial class QaDbContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseNpgsql($"Name=QaSectionDB");
        }
#if DEBUG
        optionsBuilder
            .LogTo(message => System.Diagnostics.Debug.WriteLine(message + "\n---------------------------------------------------"))
            .EnableSensitiveDataLogging(true)
            .EnableDetailedErrors();
#endif
    }
}
