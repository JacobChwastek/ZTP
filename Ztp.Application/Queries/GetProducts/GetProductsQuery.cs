using Ztp.Shared.Abstractions.Queries;
using Ztp.Application.Dto;

namespace Ztp.Application.Queries.GetProducts;

public class GetProductsQuery: IQuery<IReadOnlyList<ProductDto>>;