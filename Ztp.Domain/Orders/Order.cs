namespace Ztp.Domain.Orders;

public class Order
{
    public Guid Id { get; private set; }

    public Guid CustomerId { get; private set; }

    public List<OrderProduct> Products { get; private set; }
}