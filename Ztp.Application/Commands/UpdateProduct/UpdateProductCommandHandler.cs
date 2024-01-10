using Ztp.Domain;
using Ztp.Domain.Products;
using Ztp.Domain.Shared;
using Ztp.Shared.Abstractions.Commands;

namespace Ztp.Application.Commands.UpdateProduct;

public class UpdateProductCommandHandler(IProductRepository productRepository) : ICommandHandler<UpdateProductCommand>
{
    public async Task HandleAsync(UpdateProductCommand command)
    {
        var product = await productRepository.GetProductById(command.Id);
        
        product.UpdateProductDetails(command.Name, command.Description,new Money(command.Price, command.Currency), command.Quantity);

        await productRepository.SaveProduct(product);
    }
}