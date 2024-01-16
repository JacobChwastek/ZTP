using Marten;
using Ztp.Application.Dto;

namespace Ztp.Application.Products.Queries.GetProducts;

public class GetProductsQueryHandler
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