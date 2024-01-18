using Ztp.Domain.Contracts.v0.AggregateIdentities;
using Ztp.Shared.Contracts;

namespace Ztp.Domain.Contracts.v0.Customers.Events;

public class CustomerAdded : Event<CustomerId>
{
    private CustomerAdded()
    {
    }

    public CustomerAdded(CustomerId identifier, string firstName, string lastName, string email) : base(identifier)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
    }

    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public string Email { get; private set; }
}