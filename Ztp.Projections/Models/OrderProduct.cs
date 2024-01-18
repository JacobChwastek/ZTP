using System.ComponentModel.DataAnnotations.Schema;

namespace Ztp.Projections.Models;

public class OrderProduct
{
    public Guid Id { get; set; }

    public Guid OrderId { get; set; }
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }

    public Order Order { get; set; }

    [NotMapped]
    public decimal TotalCost => Quantity * UnitPrice;
}