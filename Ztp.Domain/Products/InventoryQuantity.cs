using Ztp.Domain.Products.Exceptions;

namespace Ztp.Domain.Products;

public record InventoryQuantity
{
    public int Value { get; }

    public InventoryQuantity(int value)
    {
        if (value < 0)
        {
            throw new NonNegativeInventoryException();
        }

        Value = value;
    }

    public static implicit operator int(InventoryQuantity quantity) => quantity.Value;
    public static implicit operator InventoryQuantity(int quantity) => new(quantity);
}