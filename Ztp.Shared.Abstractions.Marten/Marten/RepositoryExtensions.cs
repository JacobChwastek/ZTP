﻿
namespace Ztp.Shared.Abstractions.Marten.Marten;

public static class RepositoryExtensions
{
    // public static async Task<T> Get<T, TV>(this IMartenRepository<T, TV> repository, Guid id,
    //     CancellationToken cancellationToken = default) where T : class, IAggregate<TV> where TV : IAggregateIdentity
    // {
    //     var entity = await repository.Find(id, cancellationToken).ConfigureAwait(false);
    //
    //     return entity ?? throw AggregateNotFoundException.For<T>(id);
    // }
    //
    // public static async Task<long> GetAndUpdate<T, TV>(
    //     this IMartenRepository<T, TV> repository,
    //     Guid id,
    //     Action<T> action,
    //     long? expectedVersion = null,
    //     CancellationToken ct = default
    // ) where T : class, IAggregate<TV> where TV : IAggregateIdentity
    // {
    //     var entity = await repository.Get(id, ct).ConfigureAwait(false);
    //
    //     action(entity);
    //
    //     return await repository.Update(entity, expectedVersion, ct).ConfigureAwait(false);
    // }
}