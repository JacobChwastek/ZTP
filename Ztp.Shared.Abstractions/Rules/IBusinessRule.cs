namespace Ztp.Shared.Abstractions.Rules;

public interface IBusinessRule
{
    bool IsBroken();

    string Message { get; }
}