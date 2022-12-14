using Common.Models;
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
            if (entry.Entity is BaseEntity baseEntity)
            {
                baseEntity.updatedAt = now;
                if (entry.State == EntityState.Added)
                {
                    baseEntity.createdAt = now;
                }
            }
        }
        return base.SaveChanges();
    }

    public DbSet<Product> Products { get; set; }
    public DbSet<ProductCategory> ProductCategories { get; set; }
    public DbSet<ProductInventory> ProductInventories { get; set; }
}