using Ztp.Domain.Contracts.v0.AggregateIdentities;
using Ztp.Shared.Abstractions.Shared;
using Ztp.Shared.Contracts;

namespace Ztp.Domain.Contracts.v0.Products.Events;

public class ProductReservedForCart : Event<ProductId>
{
    public ProductReservedForCart()
    {
    }

    public ProductReservedForCart(ProductId identifier, string name, string description, Money price, int quantity) : base(identifier)
    {
        Name = name;
        Description = description;
        Price = price;
        Quantity = quantity;
    }

    public string Name { get; private set; }
    public string Description { get; private set; }
    public Money Price { get; private set; }
    public int Quantity { get; private set; }
}