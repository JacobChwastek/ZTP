using Ztp.Shared.Abstractions.Queries;
using Ztp.Application.Dto;

namespace Ztp.Application.Queries.GetProduct;

public class GetProductQuery : IQuery<ProductDto>
{
    public Guid ProductId { get; init; }
}