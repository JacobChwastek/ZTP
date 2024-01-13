using Ztp.Domain.Customers;
using Ztp.Shared.Abstractions.Commands;
using Ztp.Shared.Abstractions.Marten;

namespace Ztp.Application.Customers.Commands;

public class CreateCustomerCommandHandler : ICommandHandler<CreateCustomerCommand>
{
    private readonly IMartenRepository<Customer> _repository;
    
    public CreateCustomerCommandHandler(IMartenRepository<Customer> repository)
    {
        _repository = repository;
    }
    
    public async Task HandleAsync(CreateCustomerCommand command)
    {
        var customer = Customer.New(command.Name);
        
        await _repository.Add(customer);
    }
}