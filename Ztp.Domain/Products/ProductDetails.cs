using Ztp.Shared.Abstractions.Shared;

namespace Ztp.Domain.Products;

public record ProductDetails
{
    public ProductName Name { get; init; }
    public ProductDescription Description { get; init; }
    public Money Price { get; init; }
    public InventoryQuantity Quantity { get; init; }
    public InventoryQuantity ReservedProducts { get; init; }
    
    
    public int AvailableQuantity => Quantity - ReservedProducts;
    public bool Availability => Quantity - ReservedProducts > 0;
}