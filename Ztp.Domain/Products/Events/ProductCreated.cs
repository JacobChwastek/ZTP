namespace Ztp.Domain.Products.Events;

public record ProductCreated(Guid ProductId, ProductDetails ProductDetails);