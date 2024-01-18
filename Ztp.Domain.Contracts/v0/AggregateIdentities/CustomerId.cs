using Ztp.Shared.Contracts;

namespace Ztp.Domain.Contracts.v0.AggregateIdentities;

public sealed class CustomerId : StronglyTypedValue<Guid>, IAggregateIdentity
{
    public CustomerId(Guid value) : base(value)
    {
    }
    
    public static implicit operator Guid(CustomerId id) => id.Value;
    public static implicit operator CustomerId(Guid id) => new(id);
}