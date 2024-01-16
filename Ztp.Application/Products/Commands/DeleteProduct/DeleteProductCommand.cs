namespace Ztp.Application.Products.Commands.DeleteProduct;

public class DeleteProductCommand(Guid productId)
{
    public Guid ProductId { get; } = productId;
}