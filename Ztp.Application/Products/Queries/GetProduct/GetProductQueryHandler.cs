using MediatR;
using Ztp.Application.Dto;
using Ztp.Projections.Repositories;
using Ztp.Shared.Abstractions.Shared;

namespace Ztp.Application.Products.Queries.GetProduct;

public class GetProductQueryHandler : IRequestHandler<GetProductQuery, ProductDto>
{
    private readonly IProductRepository _productRepository;

    public GetProductQueryHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<ProductDto> Handle(GetProductQuery request, CancellationToken cancellationToken)
    {
        var product = await _productRepository.GetByIdAsync(request.ProductId, cancellationToken);

        return new ProductDto
        {
            CreatedAt = product.CreatedAt,
            UpdateAt = product.UpdatedAt,
            ProductId = product.Id,
            Details = new ProductDetailsDto
            {
                Name = product.Name,
                Description = product.Description,
                Price = new Money(product.Amount, product.Currency),
                Quantity = product.Quantity,
            }
        };
    }
}