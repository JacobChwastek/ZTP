using Ztp.Domain.Contracts.v0.AggregateIdentities;
using Ztp.Domain.Contracts.v0.Customers.Events;
using Ztp.Domain.Customers.Rules;
using Ztp.Shared.Abstractions.Marten.Aggregate;

namespace Ztp.Domain.Customers;

public class Customer : Aggregate<CustomerId>
{
    private Customer() { }
    
    private Customer(Guid id, string firstName, string lastName, string email)
    {
        CheckRule(new CustomerNameShouldBeValid(firstName));
        CheckRule(new CustomerNameShouldBeValid(lastName));

        var @event = new CustomerAdded(id, firstName, lastName, email);

        Enqueue(@event);
        Apply(@event);
    }
    
    public static Customer New(string firstName, string lastName, string email)
    {
        return new (Guid.NewGuid(), firstName, lastName, email);
    }
    
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public string Email { get; private set; }
    
    
    #region Apply methods
    
    private void Apply(CustomerAdded @event)
    {
        Id = new CustomerId(@event.Identifier);
        FirstName = @event.FirstName;
        LastName = @event.LastName;
        Email = @event.Email;
    }

    #endregion
}