using Ztp.Shared.Abstractions.Queries;
using Ztp.Application.Dto;
using Ztp.Domain.Products;

namespace Ztp.Application.Queries.GetProducts;

public class GetProductsQueryHandler(IProductRepository productRepository): IQueryHandler<GetProductsQuery, IReadOnlyList<ProductDto>>
{
    public async Task<IReadOnlyList<ProductDto>> HandleAsync(GetProductsQuery query)
    {
        var products = await productRepository.BrowseProducts();

        return products.Select(product => product.MapToProductDto()).ToList().AsReadOnly();
    }
}