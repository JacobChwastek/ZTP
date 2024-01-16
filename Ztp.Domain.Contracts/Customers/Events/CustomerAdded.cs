using Ztp.Shared.Abstractions.Events;

namespace Ztp.Domain.Contracts.Customers.Events;

public record CustomerAdded : IDomainEvent
{
    public CustomerAdded(Guid id, string name)
    {
        Id = id;
        Name = name;
    }

    public Guid Id { get; init; }
    public string Name { get; init; }

}