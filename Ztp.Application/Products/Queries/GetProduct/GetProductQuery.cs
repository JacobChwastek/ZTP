using Ztp.Application.Dto;
using Ztp.Shared.Abstractions.Queries;

namespace Ztp.Application.Products.Queries.GetProduct;

public class GetProductQuery : IQuery<ProductDto>
{
    public Guid ProductId { get; init; }
}