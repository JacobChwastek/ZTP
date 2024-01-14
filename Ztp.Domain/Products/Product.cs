using Ztp.Domain.Products.Events;
using Ztp.Domain.Shared;
using Ztp.Shared.Abstractions.Marten.Aggregate;

namespace Ztp.Domain.Products;

public sealed class Product : Aggregate<ProductId>
{
    public Product()
    {
    }

    public static Product New(ProductDetails productDetails)
    {
        return new Product(Guid.NewGuid(), productDetails);
    }

    private Product(Guid id, ProductDetails productDetails)
    {
        var @event = new ProductCreated(id, productDetails);

        Enqueue(@event);
        Apply(@event);
    }

    public ProductDetails? Details { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime UpdateAt { get; private set; }
    public bool IsDeleted { get; private set; }

    public void Update(string name, string description, Money price, int quantity)
    {
        var @event = new ProductUpdated(name, description, price, quantity, quantity > 0);

        Enqueue(@event);
        Apply(@event);
    }


    #region Apply Events

    private void Apply(ProductCreated @event)
    {
        Id = @event.ProductId;
        Details = @event.ProductDetails;
        CreatedAt = DateTime.Now;
        UpdateAt = DateTime.Now;
        IsDeleted = false;
    }

    private void Apply(ProductUpdated @event)
    {
        Details = new ProductDetails
        {
            Availability = @event.Availability,
            Description = new ProductDescription(@event.Description),
            InventoryQuantity = @event.InventoryQuantity,
            Price = @event.Price,
            Name = @event.Name
        };
        UpdateAt = DateTime.Now;
        IsDeleted = false;
    }

    #endregion
}