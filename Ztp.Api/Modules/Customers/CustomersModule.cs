using Microsoft.AspNetCore.Mvc;

namespace Ztp.Api.Modules.Customers;

public class CustomersModule: IApiModule
{
    public IEndpointRouteBuilder MapEndpoints(IEndpointRouteBuilder endpoints)
    {
        var group = endpoints
            .MapGroup("api/customers")
            .WithTags("Customers")
            .WithOpenApi();


        group
            .MapGet("/", async () =>
            {
                return Results.Ok("Get Customers");
            });
        
        group
            .MapGet("/{id:guid}", async ([FromQuery] Guid id) =>
            {
                return Results.Ok("Get Customer");
            });


        group
            .MapPost("/", async () =>
            {
                return Results.Ok("Create Orders");
            });
        
        return group;
    }
}