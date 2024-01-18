using MediatR;
using Ztp.Application.Dto;
using Ztp.Projections.Repositories;
using Ztp.Shared.Abstractions.Shared;

namespace Ztp.Application.Products.Queries.GetProducts;

public class GetProductsQueryHandler : IRequestHandler<GetProductsQuery, IReadOnlyList<ProductDto>>
{
    private readonly IProductRepository _productRepository;

    public GetProductsQueryHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<IReadOnlyList<ProductDto>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
    {
        var products = await _productRepository.GetAsync(cancellationToken);

        return products
            .Select(p => new ProductDto
            {
                ProductId = p.Id,
                CreatedAt = p.CreatedAt,
                UpdateAt = p.UpdatedAt,
                Details = new ProductDetailsDto
                {
                    Name = p.Name,
                    Description = p.Description,
                    Price = new Money(p.Amount, p.Currency),
                    Quantity = p.Quantity,
                }
            })
            .ToList()
            .AsReadOnly();
    }
}