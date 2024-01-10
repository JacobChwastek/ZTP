using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using Ztp.Domain.Products;
using Ztp.Domain.Shared;

namespace Ztp.Infrastructure.EF.Models;

public class ProductDbModel
{
    [Key]
    public Guid Id { get;  set; }
    public ProductDetailsDbModel? Details { get; set; }
    public bool IsDeleted { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    
    public int Version { get; set; }
    
    [MaxLength(1000)]
    public string Changelog { get; set; }
}

public class ProductDetailsDbModel
{
    [DataMember]
    [MaxLength(100)]
    public string Name { get; set; }
    
    [DataMember]
    [MaxLength(1000)]
    public string Description { get; set; }
    
    [DataMember]
    public int InventoryQuantity { get; set; }
    
    [DataMember]
    public bool Availability { get; set; }
    
    [DataMember]
    public MoneyDbModel Price { get; set; }

    public static implicit operator ProductDetails(ProductDetailsDbModel dbModel) => new()
    {
        Availability = dbModel.Availability,
        Description = dbModel.Description,
        Name = dbModel.Name,
        Price = dbModel.Price,
        InventoryQuantity = dbModel.InventoryQuantity
    };

    public static implicit operator ProductDetailsDbModel(ProductDetails productDetails) => new()
    {
        Availability = productDetails.Availability,
        Description = productDetails.Description,
        Name = productDetails.Name,
        Price = productDetails.Price,
        InventoryQuantity = productDetails.InventoryQuantity
    };
}

public class MoneyDbModel
{
    public MoneyDbModel() { }
    
    public MoneyDbModel(Money money)
    {
        Amount = money.Amount;
        Currency = (int)money.Currency;
    }
    
    public decimal Amount { get; set; }
    public int Currency { get; set; }

    public static implicit operator Money(MoneyDbModel dbModel) => new(dbModel.Amount, (Currency)dbModel.Currency);
    public static implicit operator MoneyDbModel(Money money) => new(money);
}