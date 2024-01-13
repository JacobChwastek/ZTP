using Ztp.Domain.Customers.Events;
using Ztp.Domain.Customers.Exceptions;
using Ztp.Shared.Abstractions.Aggregate;

namespace Ztp.Domain.Customers;

public class Customer : Aggregate
{
    public Customer() { }
    
    public static Customer New(string name)
    {
        return new Customer(name);
    }

    private Customer(string name)
    {
        if (string.IsNullOrEmpty(name))
        {
            throw new InvalidCustomerNameException();
        }

        var @event = new CustomerAdded(Guid.NewGuid(), name);

        Enqueue(@event);
        Apply(@event);
    }
    
    public string Name { get; private set; }

    #region Apply methods

    private void Apply(CustomerAdded @event)
    {
        Id = @event.Id;
        Name = @event.Name;
    }

    #endregion
}