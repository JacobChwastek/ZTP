using Ztp.Domain.Products;
using Ztp.Domain.Repositories;
using Ztp.Shared.Abstractions.Queries;
using Ztp.Application.Dto;

namespace Ztp.Application.Queries.GetProducts;

public class GetProductsQueryHandler(IProductRepository productRepository): IQueryHandler<GetProductsQuery, IReadOnlyList<ProductDto>>
{
    public async Task<IReadOnlyList<ProductDto>> HandleAsync(GetProductsQuery query)
    {
        var products = await productRepository.BrowseProducts();

        return products.Select(product => new ProductDto
        {
            ProductId = product.Id,
            Details = new ProductDetailsDto
            {
                Price = product.Details?.Price ?? new Money(0, Currency.EUR),
                Availability = product.Details?.Availability ?? false,
                Name = product.Details?.Name ?? string.Empty,
                Description = product.Details?.Description ?? string.Empty,
                Quantity = product.Details?.InventoryQuantity ?? 0,
            },
            Version = product.Version,
            CreatedAt = product.CreatedAt,
            UpdateAt = product.UpdateAt
        }).ToList().AsReadOnly();
    }
}