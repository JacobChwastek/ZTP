namespace Ztp.Shared.Contracts;

public abstract class Command : Message
{
}

public class Command<TIdentifier> : Command where TIdentifier : class, IAggregateIdentity
{
    protected Command()
    {
    }

    protected Command(TIdentifier identifier)
    {
        ArgumentNullException.ThrowIfNull(identifier);
        Identifier = identifier;
    }

    public TIdentifier Identifier { get; private set; }
}