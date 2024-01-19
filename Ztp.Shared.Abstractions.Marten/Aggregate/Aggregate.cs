using Marten.Schema;
using Newtonsoft.Json;
using Ztp.Shared.Abstractions.BusinessRules;
using Ztp.Shared.Abstractions.Exceptions;
using Ztp.Shared.Contracts;

namespace Ztp.Shared.Abstractions.Marten.Aggregate;

public abstract class Aggregate<TKey> : IAggregate<TKey> where TKey : StronglyTypedValue<Guid>, IAggregateIdentity
{
    public TKey Id { get; set; } = default!;

    [Identity]
    public Guid AggregateId
    {
        get => Id.Value;
        set { }
    }

    public int Version { get; protected set; }

    [JsonIgnore] private readonly Queue<object> _uncommittedEvents = new();

    public object[] DequeueUncommittedEvents()
    {
        var dequeuedEvents = _uncommittedEvents.ToArray();

        _uncommittedEvents.Clear();

        return dequeuedEvents;
    }

    protected void Enqueue(object @event)
    {
        _uncommittedEvents.Enqueue(@event);
    }
    
    protected static void CheckRule(IBusinessRule rule)
    {
        if (rule.IsBroken())
        {
            throw new BusinessRuleValidationException(rule);
        }
    }
}