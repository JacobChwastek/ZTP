namespace Ztp.Domain.Products;

public record ProductName
{
    public string Value { get; }
    
    public ProductName(string value)
    {
        if (string.IsNullOrEmpty(value))
        {
            throw new EmptyProductNameException();
        }

        Value = value;
    }

    public static implicit operator string(ProductName name) => name.Value;

    public static implicit operator ProductName(string name) => new(name);
}

public class EmptyProductNameException() : AggregateException("Product name cannot be empty");
