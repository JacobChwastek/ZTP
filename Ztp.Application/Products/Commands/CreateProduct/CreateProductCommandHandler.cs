using Ztp.Domain.Products;
using Ztp.Domain.Shared;
using Ztp.Shared.Abstractions.Commands;
using Ztp.Shared.Abstractions.Marten;

namespace Ztp.Application.Products.Commands.CreateProduct;

public class CreateProductCommandHandler : ICommandHandler<CreateProductCommand>
{
    private readonly IMartenRepository<Product> _repository;

    public CreateProductCommandHandler(IMartenRepository<Product> repository)
    {
        _repository = repository;
    }

    public async Task HandleAsync(CreateProductCommand command)
    {
        var product = Product.New(new ProductDetails
        {
            Name = new ProductName(command.Name),
            Description = new ProductDescription(command.Description),
            Price = new Money(command.Price, command.Currency),
            InventoryQuantity = new InventoryQuantity(command.Quantity),
            Availability = command.Quantity > 0
        });
        
        await _repository.Add(product);
    }
}