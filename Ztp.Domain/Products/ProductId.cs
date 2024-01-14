using Ztp.Shared.Abstractions.Marten.Aggregate;

namespace Ztp.Domain.Products;

public sealed class ProductId : StronglyTypedValue<Guid>
{
    public ProductId(Guid value) : base(value)
    {
    }

    public static implicit operator Guid(ProductId id) => id.Value;
    public static implicit operator ProductId(Guid id) => new(id);
}