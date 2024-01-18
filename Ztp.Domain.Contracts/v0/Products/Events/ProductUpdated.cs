using Ztp.Domain.Contracts.v0.AggregateIdentities;
using Ztp.Shared.Abstractions.Shared;
using Ztp.Shared.Contracts;

namespace Ztp.Domain.Contracts.v0.Products.Events;

public class ProductUpdated : Event<ProductId>
{
    public ProductUpdated() {}

    public ProductUpdated(ProductId id, string name, string description, Money price, int quantity, DateTime createdAt, DateTime updateAt) : base(id)
    {
        Name = name;
        Description = description;
        Price = price;
        Quantity = quantity;
        CreatedAt = createdAt;
        UpdateAt = updateAt;
    }

    public string Name { get; private set; }
    public string Description { get; private set; }
    public Money Price { get; private set; }
    public int Quantity { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime UpdateAt { get; private set; }
}