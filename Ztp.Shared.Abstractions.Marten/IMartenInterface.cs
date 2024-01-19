namespace Ztp.Shared.Abstractions.Marten;

public interface IMartenRepository<TEntity> where TEntity : class
{
    Task<TEntity?> FindAsync(Guid id, CancellationToken cancellationToken);
    Task<long> AddAsync(TEntity aggregate, CancellationToken cancellationToken = default);
    Task<long> UpdateAsync(TEntity aggregate, long? expectedVersion = null, CancellationToken cancellationToken = default);
    Task<long> DeleteAsync(TEntity aggregate, long? expectedVersion = null, CancellationToken cancellationToken = default);
}
