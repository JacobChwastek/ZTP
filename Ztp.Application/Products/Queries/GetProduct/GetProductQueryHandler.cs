using Ztp.Application.Dto;
using Ztp.Domain.Products;
using Ztp.Shared.Abstractions.Queries;

namespace Ztp.Application.Products.Queries.GetProduct;

public class GetProductQueryHandler(IProductRepository productRepository): IQueryHandler<GetProductQuery, ProductDto>
{
    public async Task<ProductDto> HandleAsync(GetProductQuery query)
    {
        var product = await productRepository.GetProductById(query.ProductId);

        return new ProductDto
        {
            ProductId = product.Id,
            Details = new ProductDetailsDto
            {
                Price = product.Details?.Price != null ? new MoneyDto(product.Details?.Price) : new MoneyDto(),
                Availability = product.Details?.Availability ?? false,
                Name = product.Details?.Name ?? string.Empty,
                Description = product.Details?.Description ?? string.Empty,
                Quantity = product.Details?.InventoryQuantity ?? 0,
            },
            CreatedAt = product.CreatedAt,
            UpdateAt = product.UpdateAt
        };
    }
}