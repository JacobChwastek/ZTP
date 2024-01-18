using Ztp.Shared.Contracts;

namespace Ztp.Shared.Abstractions.Marten.Aggregate;

public interface IAggregate<out TKey> where TKey : StronglyTypedValue<Guid>
{
    TKey Id { get; }
    
    Guid AggregateId { get; set; }

    int Version { get; }

    object[] DequeueUncommittedEvents();
}