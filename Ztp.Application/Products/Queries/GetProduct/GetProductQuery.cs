using MediatR;
using Ztp.Application.Dto;

namespace Ztp.Application.Products.Queries.GetProduct;

public record GetProductQuery : IRequest<ProductDto>
{
    public Guid ProductId { get; init; }
}