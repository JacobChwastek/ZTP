using System.ComponentModel.DataAnnotations.Schema;
using Ztp.Shared.Abstractions.Shared;

namespace Ztp.Projections.Models;

public class Product
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Amount { get; init; }
    public Currency Currency { get; init; }
    public int Quantity { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    
    [NotMapped]
    public bool Availability => Quantity > 0;
}