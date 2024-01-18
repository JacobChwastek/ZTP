using Ztp.Domain.Contracts.v0.AggregateIdentities;
using Ztp.Shared.Abstractions.Marten.Aggregate;

namespace Ztp.Domain.Cart;

public class Cart : Aggregate<CartId>
{
}