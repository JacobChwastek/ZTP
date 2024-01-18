namespace Ztp.Projections.Models;

public class Order
{
    public Guid Id { get; set; } 
    
    
    public Guid CustomerId { get; set; }
    public Customer Customer { get; set; }
    public ICollection<OrderProduct> OrderProducts { get; set; }
}