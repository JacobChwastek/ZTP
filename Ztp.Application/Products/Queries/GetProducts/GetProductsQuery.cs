using MediatR;
using Ztp.Application.Dto;

namespace Ztp.Application.Products.Queries.GetProducts;

public record GetProductsQuery : IRequest<IReadOnlyList<ProductDto>>;