namespace Ztp.Shared.Contracts;

public abstract class Event : Message
{
}

public class Event<TIdentifier> : Event where TIdentifier : class, IAggregateIdentity
{
    protected Event()
    {
    }

    protected Event(TIdentifier identifier)
    {
        ArgumentNullException.ThrowIfNull(identifier);
        Identifier = identifier;
    }

    public TIdentifier Identifier { get; private set; }
}