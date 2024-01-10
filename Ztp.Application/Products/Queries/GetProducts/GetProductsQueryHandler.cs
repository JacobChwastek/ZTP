using Marten;
using Ztp.Application.Dto;
using Ztp.Domain.Products;
using Ztp.Shared.Abstractions.Queries;

namespace Ztp.Application.Products.Queries.GetProducts;

public class GetProductsQueryHandler: IQueryHandler<GetProductsQuery, IReadOnlyList<ProductDto>>
{
    private readonly IDocumentSession _session;

    public GetProductsQueryHandler(IDocumentSession session)
    {
        _session = session;
    }

    public async Task<IReadOnlyList<ProductDto>> HandleAsync(GetProductsQuery query)
    {
        
        return default;
    }
}