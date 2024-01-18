using Marten;
using MassTransit;
using Ztp.Shared.Abstractions.Marten;
using Ztp.Shared.Abstractions.Marten.Aggregate;
using Ztp.Shared.Contracts;

namespace Ztp.Infrastructure.Marten;

public class MartenRepository<TEntity, TKey> : IMartenRepository<TEntity>
    where TKey : StronglyTypedValue<Guid>
    where TEntity : class, IAggregate<TKey>
{
    private readonly IDocumentSession _documentSession;
    private readonly IPublishEndpoint _publishEndpoint;

    public MartenRepository(IDocumentSession documentSession, IPublishEndpoint publishEndpoint)
    {
        _documentSession = documentSession;
        _publishEndpoint = publishEndpoint;
    }

    public Task<TEntity?> Find(Guid id, CancellationToken ct) => _documentSession.Events.AggregateStreamAsync<TEntity>(id, token: ct);

    public async Task<long> Add(TEntity aggregate, CancellationToken ct = default)
    {
        var events = aggregate.DequeueUncommittedEvents();

        _documentSession.Events.StartStream<Aggregate<TKey>>(
            aggregate.AggregateId,
            events
        );

        foreach (var @event in events)
        {
            await _publishEndpoint.Publish(@event, ct);
        }

        await _documentSession.SaveChangesAsync(ct).ConfigureAwait(false);

        return events.Length;
    }

    public async Task<long> Update(TEntity aggregate, long? expectedVersion = null, CancellationToken ct = default)
    {
        var events = aggregate.DequeueUncommittedEvents();

        var nextVersion = (expectedVersion ?? aggregate.Version) + events.Length;

        _documentSession.Events.Append(
            aggregate.AggregateId,
            nextVersion,
            events
        );

        // await _publishEndpoint.Publish(events, ct);
        await _documentSession.SaveChangesAsync(ct).ConfigureAwait(false);

        return nextVersion;
    }

    public Task<long> Delete(TEntity aggregate, long? expectedVersion = null, CancellationToken ct = default) => Update(aggregate, expectedVersion, ct);
}