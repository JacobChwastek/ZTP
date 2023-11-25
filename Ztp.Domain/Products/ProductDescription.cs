using Ztp.Shared.Abstractions.Exceptions;

namespace Ztp.Domain.Products;

public record ProductDescription
{
    public string Value { get; }

    public ProductDescription(string value)
    {
        if (string.IsNullOrEmpty(value))
        {
            throw new EmptyProductDescriptionException();
        }
        
        Value = value;
    }
    
    public static implicit operator string(ProductDescription name) => name.Value;

    public static implicit operator ProductDescription(string name) => new(name);
}

public class EmptyProductDescriptionException() : DomainException("Product description cannot be empty");