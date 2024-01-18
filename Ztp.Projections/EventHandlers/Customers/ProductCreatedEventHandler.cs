using MassTransit;
using Ztp.Domain.Contracts.v0.Products.Events;
using Ztp.Projections.Models;

namespace Ztp.Projections.EventHandlers.Customers;

public class ProductCreatedEventHandler(ProjectionsDbContext projectionsDbContext) : IConsumer<ProductCreated>
{
    public async Task Consume(ConsumeContext<ProductCreated> context)
    {
        var product = new Product
        {
            Id = context.Message.Identifier,
            CreatedAt = context.Message.CreatedAt.ToUniversalTime(),
            UpdatedAt = context.Message.UpdateAt.ToUniversalTime(),
            Description = context.Message.Description,
            Currency = context.Message.Price.Currency,
            Amount = context.Message.Price.Amount,
            Name = context.Message.Name,
            Quantity = context.Message.Quantity
        };
        
        await projectionsDbContext.Products.AddAsync(product, context.CancellationToken);
        
        await projectionsDbContext.SaveChangesAsync();
    }
}