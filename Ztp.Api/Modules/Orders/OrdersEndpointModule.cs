namespace Ztp.Api.Modules.Orders;

public class OrdersEndpointModule: IApiModule
{
    public IEndpointRouteBuilder MapEndpoints(IEndpointRouteBuilder endpoints)
    {
        var group = endpoints
            .MapGroup("api/orders")
            .WithTags("Orders")
            .WithOpenApi();

        group
            .MapGet("/", async () =>
            {
                return Results.Ok("Get Orders");
            });

        group
            .MapPost("/", async () =>
            {
                return Results.Ok("Create Orders");
            });

        return group;
    }
}