using Ztp.Domain.Products;

namespace Ztp.Application.Dto;

public class ProductDto
{
    public required Guid ProductId { get; set; }
    public required ProductDetailsDto Details { get; set; }
    public required DateTime CreatedAt { get; set; }
    public required DateTime UpdateAt { get; set; }
}

public static class MapProductToProductDto
{
    public static ProductDto MapToProductDto(this Product product)
    {
        return new ProductDto
        {
            ProductId = product.Id,
            Details = new ProductDetailsDto
            {
                Price =  product.Details?.Price != null ? new MoneyDto(product.Details?.Price) : new MoneyDto(),
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