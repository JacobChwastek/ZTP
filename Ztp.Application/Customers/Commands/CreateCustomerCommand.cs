using Ztp.Shared.Abstractions.Commands;

namespace Ztp.Application.Customers.Commands;

public class CreateCustomerCommand(string name) : ICommand
{
    public string Name { get; } = name;
}