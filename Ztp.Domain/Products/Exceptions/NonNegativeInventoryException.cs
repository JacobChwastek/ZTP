namespace Ztp.Domain.Products.Exceptions;

public class NonNegativeInventoryException() : AggregateException("Inventory quantity cannot be lower that 0");