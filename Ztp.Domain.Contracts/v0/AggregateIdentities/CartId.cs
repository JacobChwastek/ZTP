using Ztp.Shared.Contracts;

namespace Ztp.Domain.Contracts.v0.AggregateIdentities;

public sealed class CartId : StronglyTypedValue<Guid>, IAggregateIdentity
{
    public CartId(Guid value) : base(value)
    {
    }

    public static implicit operator Guid(CartId id) => id.Value;
    public static implicit operator CartId(Guid id) => new(id);
}