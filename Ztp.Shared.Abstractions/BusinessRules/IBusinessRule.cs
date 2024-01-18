namespace Ztp.Shared.Abstractions.BusinessRules;

public interface IBusinessRule
{
    bool IsBroken();
    string Message { get; }
}