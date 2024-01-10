using Ztp.Domain.Shared;

namespace Ztp.Domain.Products.Events;

public class ProductUpdated
{
    public ProductUpdated(ProductName name, ProductDescription description, Money price, InventoryQuantity inventoryQuantity, bool availability)
    {
        Name = name;
        Description = description;
        Price = price;
        InventoryQuantity = inventoryQuantity;
        Availability = availability;
    }

    public ProductName Name { get; init; }
    public ProductDescription Description { get; init; }
    public Money Price { get; init; }
    public InventoryQuantity InventoryQuantity { get; init; }
    public bool Availability { get; init; }
}