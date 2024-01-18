using Ztp.Shared.Abstractions.Commands;

namespace Ztp.Application.Customers.Commands;

public record CreateCustomerCommand(string FirstName, string LastName, string Email): ICommand;