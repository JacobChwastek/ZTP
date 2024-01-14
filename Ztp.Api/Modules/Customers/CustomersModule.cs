using MassTransit;
using Microsoft.AspNetCore.Mvc;
using Ztp.Application.Customers.Commands;
using Ztp.Shared.Abstractions.Commands;

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
            .MapPost("/", async ([FromBody] CreateCustomerCommand createProduct, ICommandDispatcher commandDispatcher, IBus bus) =>
            {
                await commandDispatcher.DispatchAsync(createProduct);
                return Results.Created();
            });
        
        return group;
    }
}