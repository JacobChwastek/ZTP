using Ztp.Shared.Abstractions.Commands;

namespace Ztp.Application.Commands.DeleteProduct;

public class DeleteProductCommand(Guid productId) : ICommand
{
    public Guid ProductId { get; } = productId;
}