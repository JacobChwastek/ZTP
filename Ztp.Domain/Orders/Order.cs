using Ztp.Domain.Orders.Events;
using Ztp.Shared.Abstractions.Marten.Aggregate;

namespace Ztp.Domain.Orders;

public class Order : Aggregate<OrderId>
{
    public Guid CustomerId { get; private set; }
    public OrderStatus Status { get; private set; }
    
    public DateTime PlaceDateUtc { get; }
    public bool IsCompleted => Status is OrderStatus.Canceled or OrderStatus.Completed;
    public List<OrderProduct> Products { get; private set; }
    
    private Order() {}
    
    private Order(Guid customerId, DateTime placeDateUtc, List<OrderProduct> orderProducts)
    {
        var @event = new OrderAdded(Guid.NewGuid(), CustomerId, new List<OrderProduct>());
        Apply(@event);
    }
    
    public static Order Create(Guid customerId,  DateTime placeDateUtc, List<OrderProduct> orderProducts)
    {
        return new Order(customerId, placeDateUtc, orderProducts);
    }
    
    #region Apply methods
    
    public void Apply(OrderAdded @event)
    {
        Id = @event.OrderId;
        CustomerId = @event.CustomerId;
        Products = @event.OrderProducts;
    }
    
    #endregion
}