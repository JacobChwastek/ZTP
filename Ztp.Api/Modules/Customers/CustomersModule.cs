using MassTransit;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Ztp.Application.Customers.Commands;
using Ztp.Application.Customers.Queries;
using Ztp.Application.Dto;

namespace Ztp.Api.Modules.Customers;

public class CustomersModule : IApiModule
{
    public IEndpointRouteBuilder MapEndpoints(IEndpointRouteBuilder endpoints)
    {
        var group = endpoints
            .MapGroup("api/customers")
            .WithTags("Customers")
            .WithOpenApi();

        group
            .MapGet("/", async (IMediator mediator) =>
            {
                var customers = await mediator.Send(new GetCustomersQuery());
                return Results.Ok(customers);
            })
            .Produces(StatusCodes.Status200OK, typeof(List<CustomerDto>));

        group
            .MapGet("/{id:guid}", async (Guid id, IMediator mediator) =>
            {
                var customer = await mediator.Send(new GetCustomerQuery(id));

                return customer is null ? Results.NotFound($"Customer not found with id: {id}") : Results.Ok(customer);
            })
            .Produces(StatusCodes.Status200OK, typeof(CustomerDto))
            .Produces(StatusCodes.Status404NotFound, typeof(EmptyResult));

        group
            .MapPost("/", async ([FromBody] CreateCustomerCommand createCustomer, IPublishEndpoint publishEndpoint) =>
            {
                await publishEndpoint.Publish(createCustomer);
                return Results.Created();
            });
        

        return group;
    }
}