using Ztp.Domain.Shared;

namespace Ztp.Domain.Products;

public sealed class Product
{
    public Product()
    {
        Id = Guid.NewGuid();
        CreatedAt = DateTime.Now;
        UpdateAt = DateTime.Now;
    }

    internal Product(Guid id, ProductDetails productDetails, DateTime createdAt, DateTime updateAt, int version)
    {
        Id = id;
        Details = productDetails;
        CreatedAt = createdAt;
        UpdateAt = updateAt;
    }
    
    public Guid Id { get; }
    public DateTime CreatedAt { get; }
    public ProductDetails? Details { get; private set; }
    public DateTime UpdateAt { get; private set; }
    public bool IsDeleted { get; private set; }

    public void UpdateProductDetails(string name, string description, Money price, int quantity)
    {
        Details = new ProductDetails
        {
            Name = name,
            Description = description,
            Availability = quantity > 0,
            Price = price,
            InventoryQuantity = quantity
        };
        
        UpdateAt = DateTime.Now;
    }

    public void DeleteProduct()
    {
        IsDeleted = true;
    }
}