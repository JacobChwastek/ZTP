using Ztp.Shared.Abstractions.Marten.Aggregate;
using Ztp.Shared.Contracts;

namespace Ztp.Domain.Orders;

public sealed class OrderId : StronglyTypedValue<Guid>
{
    public OrderId(Guid value) : base(value)
    {
    }

    public static implicit operator Guid(OrderId id) => id.Value;
    public static implicit operator OrderId(Guid id) => new(id);
}