using Ztp.Shared.Abstractions.Shared;

namespace Ztp.Domain.Products;

public record ProductDetails
{
    public ProductName Name { get; init; }
    public ProductDescription Description { get; init; }
    public Money Price { get; init; }
    public InventoryQuantity InventoryQuantity { get; init; }
    public bool Availability => InventoryQuantity > 0;
}