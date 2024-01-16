using Marten.Schema;
using Newtonsoft.Json;

namespace Ztp.Shared.Abstractions.Marten.Aggregate;

public abstract class Aggregate<TKey> : IAggregate<TKey> where TKey : StronglyTypedValue<Guid>
{
    public TKey Id { get; set; } = default!;

    [Identity]
    public Guid AggregateId
    {
        get => Id.Value;
        set { }
    }

    public int Version { get; protected set; }

    [JsonIgnore] private readonly Queue<object> uncommittedEvents = new();

    public object[] DequeueUncommittedEvents()
    {
        var dequeuedEvents = uncommittedEvents.ToArray();

        uncommittedEvents.Clear();

        return dequeuedEvents;
    }

    protected void Enqueue(object @event)
    {
        uncommittedEvents.Enqueue(@event);
    }
}