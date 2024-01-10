using Ztp.Domain.Products;
using Ztp.Shared.Abstractions.Commands;

namespace Ztp.Application.Commands.DeleteProduct;

public class DeleteProductCommandHandler(IProductRepository productRepository): ICommandHandler<DeleteProductCommand>
{
    public async Task HandleAsync(DeleteProductCommand command)
    {
        var product = await productRepository.GetProductById(command.ProductId);
        
        product.DeleteProduct();

        await productRepository.SaveProduct(product);
    }
}