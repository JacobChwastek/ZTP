using Ztp.Domain.Contracts.v0.AggregateIdentities;
using Ztp.Domain.Contracts.v0.Products;
using Ztp.Domain.Contracts.v0.Products.Events;
using Ztp.Shared.Abstractions.Marten.Aggregate;
using Ztp.Shared.Abstractions.Shared;

namespace Ztp.Domain.Products;

public sealed class Product : Aggregate<ProductId>
{
    private Product()
    {
    }

    private Product(Guid id, ProductDetails productDetails)
    {
        var @event = new ProductCreated(id, productDetails.Name, productDetails.Description, productDetails.Price, productDetails.InventoryQuantity, DateTime.Now, DateTime.Now);

        Enqueue(@event);
        Apply(@event);
    }

    public static Product New(ProductDetails productDetails)
    {
        return new Product(Guid.NewGuid(), productDetails);
    }

    public ProductDetails Details { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime UpdateAt { get; private set; }

    public void Update(string name, string description, Money price, int quantity)
    {
        var @event = new ProductUpdated(Id, name, description, price, quantity, CreatedAt, DateTime.Now);

        Enqueue(@event);
        Apply(@event);
    }
    
    #region Apply Events

    private void Apply(ProductCreated @event)
    {
        Id = @event.Identifier;
        Details = new ProductDetails
        {
            Description = @event.Description,
            InventoryQuantity = @event.Quantity,
            Name = new ProductName(@event.Name),
            Price = @event.Price
        };
        CreatedAt = @event.CreatedAt;
        UpdateAt = @event.UpdateAt;
    }

    private void Apply(ProductUpdated @event)
    {
        Details = new ProductDetails
        {
            Description = @event.Description,
            InventoryQuantity = @event.Quantity,
            Price = @event.Price,
            Name = @event.Name
        };
        UpdateAt = DateTime.Now;
    }

    #endregion
}