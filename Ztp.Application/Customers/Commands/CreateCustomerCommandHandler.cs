using MassTransit;
using Ztp.Domain.Customers;
using Ztp.Shared.Abstractions.Marten;

namespace Ztp.Application.Customers.Commands;

public class CreateCustomerCommandConsumer(IMartenRepository<Customer> repository) : IConsumer<CreateCustomerCommand>
{
    public async Task Consume(ConsumeContext<CreateCustomerCommand> context)
    {
        var customer = Customer.New(context.Message.FirstName, context.Message.LastName, context.Message.Email);

        await repository.Add(customer);
    }
}