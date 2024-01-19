using Microsoft.EntityFrameworkCore;
using Ztp.Projections.Models;
using Ztp.Shared.Abstractions.Shared;

namespace Ztp.Projections;

public class ProjectionsDbContext(DbContextOptions<ProjectionsDbContext> options) : DbContext(options)
{
    internal DbSet<Customer> Customers { get; set; }
    internal DbSet<Product> Products { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.Entity<Customer>(entity =>
        {
            entity.ToTable("customers");
            entity.HasKey(x => x.Id);
            entity.Property(x => x.FirstName).IsRequired().HasMaxLength(200);
            entity.Property(x => x.LastName).IsRequired().HasMaxLength(500);
            entity.Property(x => x.Email);
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.ToTable("products");
            entity.HasKey(x => x.Id);
            entity.HasQueryFilter(x => !x.IsDeleted);
            
            entity
                .Property(x => x.Quantity)
                .IsRequired();
            entity
                .Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(200);

            entity
                .Property(x => x.IsDeleted)
                .HasDefaultValue(false);
            
            entity
                .Property(x => x.Currency)
                .HasConversion(
                    v => v.ToString(),
                    v => (Currency)Enum.Parse(typeof(Currency), v));
        });
    }
}