using System.Text.RegularExpressions;
using Ztp.Shared.Abstractions.BusinessRules;

namespace Ztp.Domain.Customers.Rules;

public class CustomerNameShouldBeValid(string name) : IBusinessRule
{
    public bool IsBroken()
    {
        return string.IsNullOrEmpty(name) || !Regex.IsMatch(name, @"^[a-zA-Z]+$");
    }

    public string Message => "Customer name cannot be empty and can only contain letters";

}