using System.Text.Json.Serialization;
using Ztp.Shared.Abstractions.Exceptions;

namespace Ztp.Shared.Abstractions.Shared;

public record Money
{
    [JsonPropertyName("amount")]
    public PositiveAmount Amount { get; init; }

    [JsonPropertyName("currency")]
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public Currency Currency { get; init; }

    private Money()
    {
    }

    [JsonConstructor]
    public Money(PositiveAmount amount, Currency currency)
    {
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

    public static Money operator -(Money left, Money right)
    {
        if (left.Currency != right.Currency)
        {
            throw new MoneyOperationsArePossibleOnlyForSameCurrency();
        }

        return left with { Amount = left.Amount + right.Amount };
    }
}

public class MoneyOperationsArePossibleOnlyForSameCurrency() : DomainException("Money operations are possible only for same currency");