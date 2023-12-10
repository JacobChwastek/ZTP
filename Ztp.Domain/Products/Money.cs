using Ztp.Shared.Abstractions.Exceptions;

namespace Ztp.Domain.Products;

public record Money
{
    public decimal Amount { get; init; }
    public Currency Currency { get; }

    public Money()
    {
        
    }

    public Money(decimal amount, Currency currency)
    {
        if (amount < 0)
        {
            throw new NegativeAmountException();
        }

        Amount = amount;
        Currency = currency;
    }

    public static Money operator *(Money money, uint times)
    {
        return money with { Amount = money.Amount * times };
    }
    
    public static Money operator +(Money left, Money right)
    {
        if (left.Currency != right.Currency)
        {
            throw new MoneyOperationsArePossibleOnlyForSameCurrency();
        }

        return left with { Amount = left.Amount + right.Amount };
    }  
    
    public static Money operator - (Money left, Money right)
    {
        if (left.Currency != right.Currency)
        {
            throw new MoneyOperationsArePossibleOnlyForSameCurrency();
        }

        return left with { Amount = left.Amount + right.Amount };
    }
}

public enum Currency
{
    PLN = 1,
    EUR = 2,
    USD = 3
}

public class MoneyOperationsArePossibleOnlyForSameCurrency() : DomainException("Money operations are possible only for same currency");
public class NegativeAmountException() : DomainException("Money amount cannot be below 0");
