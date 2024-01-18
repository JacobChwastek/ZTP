using MassTransit;
using Ztp.Domain.Products;
using Ztp.Shared.Abstractions.Marten;
using Ztp.Shared.Abstractions.Shared;

namespace Ztp.Application.Products.Commands.CreateProduct;

public class CreateProductCommandHandler(IMartenRepository<Product> repository) : IConsumer<CreateProductCommand>
{
    public async Task Consume(ConsumeContext<CreateProductCommand> context)
    {
        var productDetails = new ProductDetails
        {
            Name = context.Message.Name,
            Description = context.Message.Description,
            InventoryQuantity = context.Message.Quantity,
            Price = new Money(context.Message.Amount, context.Message.Currency)
        };

        var product = Product.New(productDetails);
        await repository.Add(product);
    }
}