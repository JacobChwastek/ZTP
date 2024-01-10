namespace Ztp.Domain.Orders.Events;

public record OrderAdded(Guid OrderId, Guid CustomerId, List<OrderProduct> OrderProducts);