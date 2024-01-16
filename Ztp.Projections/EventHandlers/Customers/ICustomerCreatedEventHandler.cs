using MassTransit;
using Ztp.Domain.Contracts.Customers.Events;
using Ztp.Projections.Models;

namespace Ztp.Projections.EventHandlers.Customers;

public class CustomerAddedEventHandler : IConsumer<CustomerAdded>
{
    private readonly ProjectionsDbContext _projectionsDbContext;

    public CustomerAddedEventHandler(ProjectionsDbContext projectionsDbContext)
    {
        _projectionsDbContext = projectionsDbContext;
    }

    public async Task Consume(ConsumeContext<CustomerAdded> context)
    {
        var customer = new Customer
        {
            Id = context.Message.Id,
            Name = context.Message.Name
        };

        await _projectionsDbContext.Customers.AddAsync(customer);

        await _projectionsDbContext.SaveChangesAsync();
    }
}
