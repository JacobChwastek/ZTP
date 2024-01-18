using MassTransit;
using Ztp.Domain.Contracts.v0.Customers.Events;
using Ztp.Projections.Models;

namespace Ztp.Projections.EventHandlers.Customers;

public class CustomerAddedEventHandler(ProjectionsDbContext projectionsDbContext) : IConsumer<CustomerAdded>
{
    public async Task Consume(ConsumeContext<CustomerAdded> context)
    {
        var customer = new Customer
        {
            Id = context.Message.Identifier,
            FirstName = context.Message.FirstName,
            LastName = context.Message.LastName,
            Email = context.Message.Email,
            CreatedAt = context.Message.CreationDate,
            UpdatedAt = context.Message.CreationDate
        };

        await projectionsDbContext.Customers.AddAsync(customer, context.CancellationToken);

        await projectionsDbContext.SaveChangesAsync();
    }
}