using Microsoft.AspNet.Identity.EntityFramework;
using News_Article_Project.Models;
using System;
using System.Configuration;
using System.Data.Entity;
using System.Reflection.Emit;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
{
    public DbSet<Topic> Topics { get; set; }
    public DbSet<Article> Articles { get; set; }
    public DbSet<Source> Sources { get; set; }

    public ApplicationDbContext()
        : base(GetConnectionString(), throwIfV1Schema: false)
    {
    }

    private static string GetConnectionString()
    {
        var env = Environment.GetEnvironmentVariable("TG_DB_CONN");
        if (!string.IsNullOrEmpty(env))
            return env;

        return "Host=localhost;Port=5432;Database=unKnown;Username=unKnown;Password=unKnown;";
    }
    public static ApplicationDbContext Create()
    {
        return new ApplicationDbContext();
    }

    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        
        modelBuilder.Entity<Source>()
            .HasIndex(s => s.Name)
            .IsUnique();

        modelBuilder.Entity<Topic>()
            .HasIndex(s => s.Name)
            .IsUnique();
    }
}