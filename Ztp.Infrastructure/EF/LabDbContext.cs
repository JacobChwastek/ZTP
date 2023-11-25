using Microsoft.EntityFrameworkCore;
using Ztp.Infrastructure.EF.Models;

namespace Ztp.Infrastructure.EF;

public sealed class LabDbContext: DbContext
{
    public LabDbContext(DbContextOptions<LabDbContext> options) : base(options)
    {
        Database.EnsureCreated();
    }

    public DbSet<ProductDbModel> Products { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.HasDefaultContainer("Products");
        builder.Entity<ProductDbModel>()
            .ToContainer("Products")
            .HasPartitionKey(o => o.Id)
            .HasNoDiscriminator();
        
        builder.Entity<ProductDbModel>()
            .Property(x => x.Changelog)
            .HasMaxLength(1000);
        
        builder.Entity<ProductDbModel>().HasQueryFilter(x => !x.IsDeleted);
    }
}