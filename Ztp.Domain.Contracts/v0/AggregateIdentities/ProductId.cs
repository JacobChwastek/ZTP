using Ztp.Shared.Contracts;

namespace Ztp.Domain.Contracts.v0.AggregateIdentities;

public sealed class ProductId : StronglyTypedValue<Guid>, IAggregateIdentity
{
    public ProductId(Guid value) : base(value)
    {
    }

    public static implicit operator Guid(ProductId id) => id.Value;
    public static implicit operator ProductId(Guid id) => new(id);
}