namespace Ztp.Shared.Abstractions.Events;

public interface IDomainEvent
{
    public Guid Id { get; }
}