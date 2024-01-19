using Ztp.Shared.Contracts;

namespace Ztp.Shared.Abstractions.Marten.Aggregate;

public interface IAggregate<TKey> where TKey : StronglyTypedValue<Guid>, IAggregateIdentity
{
    TKey Id { get; }
    
    Guid AggregateId { get; set; }

    int Version { get; }

    object[] DequeueUncommittedEvents();
}