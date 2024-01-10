using Ztp.Shared.Abstractions.Aggregate;
using Ztp.Shared.Abstractions.Marten;
using Ztp.Shared.Abstractions.OptimisticConcurrency;

namespace Ztp.Infrastructure.Marten.Repositories;

public class MartenRepositoryWithETagDecorator<T>: IMartenRepository<T>
    where T : class, IAggregate
{
    private readonly IMartenRepository<T> _inner;
    private readonly IExpectedResourceVersionProvider _expectedResourceVersionProvider;
    private readonly INextResourceVersionProvider _nextResourceVersionProvider;

    public MartenRepositoryWithETagDecorator(
        IMartenRepository<T> inner,
        IExpectedResourceVersionProvider expectedResourceVersionProvider,
        INextResourceVersionProvider nextResourceVersionProvider
    )
    {
        _inner = inner;
        _expectedResourceVersionProvider = expectedResourceVersionProvider;
        _nextResourceVersionProvider = nextResourceVersionProvider;
    }

    public Task<T?> Find(Guid id, CancellationToken cancellationToken) => _inner.Find(id, cancellationToken);

    public async Task<long> Add(T aggregate, CancellationToken cancellationToken = default)
    {
        var nextExpectedVersion = await _inner.Add(
            aggregate,
            cancellationToken
        ).ConfigureAwait(true);

        _nextResourceVersionProvider.TrySet(nextExpectedVersion.ToString());

        return nextExpectedVersion;
    }

    public async Task<long> Update(T aggregate, long? expectedVersion = null,
        CancellationToken cancellationToken = default)
    {
        var nextExpectedVersion = await _inner.Update(
            aggregate,
            expectedVersion ?? GetExpectedVersion(),
            cancellationToken
        ).ConfigureAwait(true);

        _nextResourceVersionProvider.TrySet(nextExpectedVersion.ToString());

        return nextExpectedVersion;
    }

    public async Task<long> Delete(T aggregate, long? expectedVersion = null, CancellationToken cancellationToken = default)
    {
        var nextExpectedVersion = await _inner.Delete(
            aggregate,
            expectedVersion ?? GetExpectedVersion(),
            cancellationToken
        ).ConfigureAwait(true);

        _nextResourceVersionProvider.TrySet(nextExpectedVersion.ToString());

        return nextExpectedVersion;
    }

    private long? GetExpectedVersion()
    {
        var value = _expectedResourceVersionProvider.Value;

        if (string.IsNullOrWhiteSpace(value) || !long.TryParse(value, out var expectedVersion))
            return null;

        return expectedVersion;
    }
}