namespace Ztp.Domain.Orders;

public interface IOrderRepository
{
    Task<Order> GetByIdAsync(Guid id);

    Task Add(Order order);
}