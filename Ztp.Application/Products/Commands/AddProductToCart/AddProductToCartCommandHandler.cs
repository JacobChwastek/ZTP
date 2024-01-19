using MassTransit;
using Ztp.Domain.Products;
using Ztp.Shared.Abstractions.Marten;

namespace Ztp.Application.Products.Commands.AddProductToCart;

public class AddProductToCartCommandHandler(IMartenRepository<Product> repository) : IConsumer<AddProductToCartCommand>
{
    public async Task Consume(ConsumeContext<AddProductToCartCommand> context)
    {
        var product = await repository.FindAsync(context.Message.ProductId, context.CancellationToken);

        if (product is null)
        {
            throw new InvalidOperationException($"Product with id {context.Message.ProductId} not found");
        }

        // product.AddToCart(context.Message.Quantity);
    }
}