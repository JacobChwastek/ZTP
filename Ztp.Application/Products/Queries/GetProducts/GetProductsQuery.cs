using Ztp.Application.Dto;
using Ztp.Shared.Abstractions.Queries;

namespace Ztp.Application.Products.Queries.GetProducts;

public class GetProductsQuery: IQuery<IReadOnlyList<ProductDto>>;