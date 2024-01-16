using Microsoft.EntityFrameworkCore;
using Ztp.Projections.Models;

namespace Ztp.Projections;

public class ProjectionsDbContext(DbContextOptions<ProjectionsDbContext> options) : DbContext(options)
{
    public DbSet<Customer> Customers { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Customer>()
            .ToTable("customers");
        
        modelBuilder.Entity<Customer>()
            .Property(x => x.Name).HasMaxLength(200);

        modelBuilder.Entity<Customer>()
            .HasKey(x => x.Id);
    }
}