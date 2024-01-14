using Ztp.Domain.Orders.Events;
using Ztp.Shared.Abstractions.Marten.Aggregate;

namespace Ztp.Domain.Orders;

public class Order : Aggregate<OrderId>
{
    private Order() { }

    private Order(Guid customerId, List<OrderProduct> orderProducts)
    {
        var @event = new OrderAdded(Guid.NewGuid(), CustomerId, new List<OrderProduct>());
        Apply(@event);
    }

    public static Order New(Guid customerId, List<OrderProduct> orderProducts)
    {
        return new Order(customerId, orderProducts);
    }

    public Guid CustomerId { get; private set; }
    public List<OrderProduct> Products { get; private set; }

    public void Apply(OrderAdded @event)
    {
        Id = @event.OrderId;
        CustomerId = @event.CustomerId;
        Products = @event.OrderProducts;
    }
}