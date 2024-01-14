namespace Ztp.Shared.Abstractions.Marten;

public interface IMartenRepository<TEntity> where TEntity : class
{
    Task<TEntity?> Find(Guid id, CancellationToken cancellationToken);
    Task<long> Add(TEntity aggregate, CancellationToken cancellationToken = default);
    Task<long> Update(TEntity aggregate, long? expectedVersion = null, CancellationToken cancellationToken = default);
    Task<long> Delete(TEntity aggregate, long? expectedVersion = null, CancellationToken cancellationToken = default);
}
