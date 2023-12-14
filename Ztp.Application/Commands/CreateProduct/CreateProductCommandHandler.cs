using Ztp.Domain.Products;
using Ztp.Domain.Repositories;
using Ztp.Shared.Abstractions.Commands;

namespace Ztp.Application.Commands.CreateProduct;

public class CreateProductCommandHandler(IProductRepository productRepository) : ICommandHandler<CreateProductCommand, Guid>
{
    public async Task<Guid> HandleAsync(CreateProductCommand command)
    {
        var product = new Product();
        product.UpdateProductDetails(command.Name, command.Description, new Money(command.Price, command.Currency), command.Quantity);

        await productRepository.SaveProduct(product);

        return product.Id;
    }
}