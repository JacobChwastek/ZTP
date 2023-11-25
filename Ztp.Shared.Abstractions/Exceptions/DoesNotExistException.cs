namespace Ztp.Shared.Abstractions.Exceptions;

public class DoesNotExistException : Exception
{
    public DoesNotExistException(string? objectName = null, string? id = null) : base("Object" +
        (objectName != null ? $" {objectName} " : "") + (id != null ? $" with id {id} " : "") +
        "not found in the system")
    {
    }
}