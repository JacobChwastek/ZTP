namespace Ztp.Domain.Customers.Exceptions;

public class InvalidCustomerNameException() : AggregateException("Customer name cannot be empty");