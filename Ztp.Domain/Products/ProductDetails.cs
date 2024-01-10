using Ztp.Domain.Shared;

namespace Ztp.Domain.Products;

public record ProductDetails
{
    public required ProductName Name { get; init; }
    public required ProductDescription Description { get; init; }
    public required Money Price { get; init; }
    public required InventoryQuantity InventoryQuantity { get; init; }
    public required bool Availability { get; init; }
}