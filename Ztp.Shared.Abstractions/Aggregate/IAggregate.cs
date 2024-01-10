using Ztp.Shared.Abstractions.Projection;

namespace Ztp.Shared.Abstractions.Aggregate;

public interface IAggregate: IAggregate<Guid>
{
}

public interface IAggregate<out T>: IProjection
{
    T Id { get; }
    int Version { get; }

    object[] DequeueUncommittedEvents();
}