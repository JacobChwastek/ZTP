using Ztp.Application.Dto;
using Ztp.Domain.Products;
using Ztp.Shared.Abstractions.Queries;

namespace Ztp.Application.Products.Queries.GetProduct;

public class GetProductQueryHandler(): IQueryHandler<GetProductQuery, ProductDto>
{
    public async Task<ProductDto> HandleAsync(GetProductQuery query)
    {
        return default;
    }
}