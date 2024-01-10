namespace Ztp.Domain.Products.Exceptions;

public class EmptyProductNameException() : AggregateException("Product name cannot be empty");