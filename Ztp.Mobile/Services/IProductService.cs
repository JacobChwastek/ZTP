using Ztp.Mobile.Models;

namespace Ztp.Mobile.Services;

public interface IProductService
{
    public Task<IEnumerable<Product>> GetProductsAsync();

    public Task<Product> GetProductAsync(Guid productId);

    public Task UpdateProductAsync(UpdateProductRequest productRequest);

    public Task<bool> DeleteProductAsync(Guid productId);
    
    public Task AddProductAsync(CreateProduct productRequest);
}