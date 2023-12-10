using Ztp.Domain.Products;

namespace Ztp.Application.Dto;

public class MoneyDto
{
    public MoneyDto()
    {
        
    }
    
    public MoneyDto(Money? price)
    {
        if (price is null)
        {
            Amount = 0;
            Currency = "";
        }
        else
        {
            Amount = price.Amount;
            Currency = Enum.GetName(typeof(Currency), price.Currency);
        }
    }
    
    public decimal Amount { get; set; }
    public string? Currency { get; set;  }
}