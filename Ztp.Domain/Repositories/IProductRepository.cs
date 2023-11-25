using Ztp.Domain.Products;

namespace Ztp.Domain.Repositories;

public interface IProductRepository
{
    Task SaveProduct(Product product, CancellationToken cancellationToken = default);
    Task<IReadOnlyList<Product>> BrowseProducts(CancellationToken cancellationToken = default);
    Task<Product> GetProductById(Guid productId, CancellationToken cancellationToken = default);
}