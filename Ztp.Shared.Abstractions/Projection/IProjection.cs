namespace Ztp.Shared.Abstractions.Projection;

public interface IProjection
{
    void When(object @event);
}

public interface IVersionedProjection: IProjection
{
    public ulong LastProcessedPosition { get; set; }
}