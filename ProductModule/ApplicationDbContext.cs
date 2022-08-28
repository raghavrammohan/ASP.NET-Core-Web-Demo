using Microsoft.EntityFrameworkCore;
using ProductModule.Models;

namespace ProductModule;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions options) : base(options)
    {
        Database.EnsureCreated();
    }

    public override int SaveChanges()
    {
        var now = DateTime.UtcNow;
        var entries = ChangeTracker
            .Entries()
            .Where(e => e.State == EntityState.Added || e.State == EntityState.Modified);

        foreach (var entry in entries)
        {
            if (entry.Entity is SystemEntity sysEntity)
            {
                sysEntity.updatedAt = now;
                if (entry.State == EntityState.Added)
                {
                    sysEntity.createdAt = now;
                }
            }
        }
        return base.SaveChanges();
    }

    public DbSet<Product> Product { get; set; }
}