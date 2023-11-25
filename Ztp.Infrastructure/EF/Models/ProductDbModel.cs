using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using Ztp.Domain.Products;

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
    public string Name { get; set; }
    
    [DataMember]
    public string Description { get; set; }
    
    [DataMember]
    public int InventoryQuantity { get; set; }
    
    [DataMember]
    public bool Availability { get; set; }
    
    [DataMember]
    public Money Price { get; set; }
}