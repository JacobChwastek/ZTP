using Ztp.Domain.Products;
using Ztp.Infrastructure.EF;

namespace Ztp.Infrastructure.Repositories;

internal class ProductRepository(LabDbContext dbContext) : IProductRepository
{
    public Task SaveProduct(Product product, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<IReadOnlyList<Product>> BrowseProducts(CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<Product> GetProductById(Guid productId, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}