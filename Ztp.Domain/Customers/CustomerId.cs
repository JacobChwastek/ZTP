using Ztp.Shared.Abstractions.Marten.Aggregate;

namespace Ztp.Domain.Customers;

public sealed class CustomerId : StronglyTypedValue<Guid>
{
    public CustomerId(Guid value) : base(value)
    {
    }
    
    public static implicit operator Guid(CustomerId id) => id.Value;
    public static implicit operator CustomerId(Guid id) => new(id);
}