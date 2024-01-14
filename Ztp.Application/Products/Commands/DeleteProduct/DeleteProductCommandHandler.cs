using Ztp.Shared.Abstractions.Commands;

namespace Ztp.Application.Products.Commands.DeleteProduct;

public class DeleteProductCommandHandler(): ICommandHandler<DeleteProductCommand>
{
    public async Task HandleAsync(DeleteProductCommand command)
    {
        
    }
}