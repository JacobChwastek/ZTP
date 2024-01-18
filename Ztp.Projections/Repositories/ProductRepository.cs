using Microsoft.EntityFrameworkCore;
using Ztp.Projections.Models;

namespace Ztp.Projections.Repositories;

public interface IProductRepository
{
    Task<Product> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task<List<Product>> GetAsync(CancellationToken cancellationToken = default);
    Task AddAsync(Product customer, CancellationToken cancellationToken = default);
    Task UpdateAsync(Product customer, CancellationToken cancellationToken = default);
}

public class ProductRepository(ProjectionsDbContext projectionsDbContext) : IProductRepository
{
    public async Task<Product> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await projectionsDbContext.Products.SingleOrDefaultAsync(x => x.Id == id, cancellationToken: cancellationToken)!;
    }

    public async Task<List<Product>> GetAsync(CancellationToken cancellationToken = default)
    {
        return await projectionsDbContext.Products.ToListAsync(cancellationToken: cancellationToken);
    }

    public Task AddAsync(Product customer, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(Product customer, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}