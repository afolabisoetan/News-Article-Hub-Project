using Microsoft.AspNet.Identity.EntityFramework;
using News_Article_Project.Models;
using System.Data.Entity;
using System.Reflection.Emit;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
{
    public DbSet<Topic> Topics { get; set; }
    public DbSet<Article> Articles { get; set; }
    public DbSet<Source> Sources { get; set; }

    public ApplicationDbContext()
        : base("DefaultConnection", throwIfV1Schema: false)
    {
    }

    public static ApplicationDbContext Create()
    {
        return new ApplicationDbContext();
    }

    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Make Name unique
        modelBuilder.Entity<Source>()
            .HasIndex(s => s.Name)
            .IsUnique();

        modelBuilder.Entity<Topic>()
            .HasIndex(s => s.Name)
            .IsUnique();
    }
}