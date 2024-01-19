namespace Ztp.Application.Products.Commands.AddProductToCart;

public record AddProductToCartCommand(Guid ProductId, int Quantity);