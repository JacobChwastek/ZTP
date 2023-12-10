using System.Collections.Concurrent;
using Ztp.Domain.Products;
using Ztp.Domain.Repositories;

namespace Ztp.Api.Bdd.Tests.Shared;

public class TestProductRepository: IProductRepository
{
    private readonly ConcurrentDictionary<Guid, Product> _products = new();
    
    public async Task SaveProduct(Product product, CancellationToken cancellationToken = default)
    {
        await Task.CompletedTask;

        if (!_products.TryAdd(product.Id, product))
        {
            throw new InvalidOperationException("Product already exists");
        }
    }

    public async Task<IReadOnlyList<Product>> BrowseProducts(CancellationToken cancellationToken = default)
    {
        await Task.CompletedTask;
        return _products.Values.ToList().AsReadOnly();
    }

    public async Task<Product> GetProductById(Guid productId, CancellationToken cancellationToken = default)
    {
        await Task.CompletedTask;
        return _products.TryGetValue(productId, out var product) ? product : null;
    }
}