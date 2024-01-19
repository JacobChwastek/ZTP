namespace Ztp.Api.Modules.Cart;

public class CartModule : IApiModule
{
    public IEndpointRouteBuilder MapEndpoints(IEndpointRouteBuilder endpoints)
    {
        var group = endpoints
            .MapGroup("api/cart")
            .WithTags("Cart")
            .WithOpenApi();
        
        group
            .MapGet("/", async () =>
            {
                return Results.Ok("Get cart");
            });

        group
            .MapPost("/clear", () =>
            {
                return Results.Ok("Cart cleared");
            });
        
        group
            .MapPut("/products/{productId:guid}", async (Guid productId) =>
            {
                return Results.Ok($"Product {productId} adjusted at cart");
            });
        

        return group;
    }
}