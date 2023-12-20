using Ztp.Web.Models;
using Ztp.Web.ViewModels;

namespace Ztp.Web.Services;

public interface IProductApiService
{
    public Task<List<Product>?> GetProducts();
    public Task<Product?> GetProduct(Guid id);
    public Task<ValidationResponse> CreateProduct(CreateProductViewModel productViewModel);
    public Task<ValidationResponse> UpdateProduct(UpdateProductViewModel productViewModel);
    public Task DeleteProduct(Guid id);
}