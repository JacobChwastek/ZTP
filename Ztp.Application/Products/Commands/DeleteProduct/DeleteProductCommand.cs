using Ztp.Shared.Abstractions.Commands;

namespace Ztp.Application.Products.Commands.DeleteProduct;

public class DeleteProductCommand(Guid productId) : ICommand
{
    public Guid ProductId { get; } = productId;
}