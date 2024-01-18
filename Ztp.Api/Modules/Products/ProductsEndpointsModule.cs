using MassTransit;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OutputCaching;
using Ztp.Api.Filters;
using Ztp.Application.Dto;
using Ztp.Application.Products.Commands.CreateProduct;
using Ztp.Application.Products.Commands.UpdateProduct;
using Ztp.Application.Products.Queries.GetProduct;
using Ztp.Application.Products.Queries.GetProducts;

namespace Ztp.Api.Modules.Products;

public class ProductsModule : IApiModule
{
    public IEndpointRouteBuilder MapEndpoints(IEndpointRouteBuilder endpoints)
    {
        var group = endpoints
            .MapGroup("api/products")
            .WithTags("Products")
            .WithOpenApi();

        group
            .MapGet("/", async (IMediator mediator) =>
            {
                var products = await mediator.Send(new GetProductsQuery());
                return Results.Ok(products);
            })
            .CacheOutput(builder => builder.Tag("Products"))
            .Produces(StatusCodes.Status200OK, typeof(IReadOnlyList<ProductDto>));

        group
            .MapGet("/{productId:guid}",
                async (Guid productId, IMediator mediator) =>
                {
                    var product = await mediator.Send(new GetProductQuery { ProductId = productId });

                    return product is null ? Results.NotFound() : Results.Ok(product);
                })
            .CacheOutput(p =>
            {
                p.SetVaryByQuery(["productId"]);
                p.Tag("Products");
            })
            .Produces(StatusCodes.Status200OK, typeof(ProductDto))
            .Produces(StatusCodes.Status404NotFound, typeof(EmptyResult));

        group
            .MapPost("/",
                async ([FromBody] CreateProductCommand createProduct, IPublishEndpoint publishEndpoint,
                    IOutputCacheStore cache, CancellationToken token) =>
                {
                    await publishEndpoint.Publish(createProduct, token);
                    await cache.EvictByTagAsync("Products", token);
                    return Results.Ok();
                })
            .AddEndpointFilter<ValidatorFilter<CreateProductCommand>>();

        group
            .MapPut("/",
                async ([FromBody] UpdateProductCommand updateProduct, IOutputCacheStore cache,
                    CancellationToken token) =>
                {
                    await cache.EvictByTagAsync("Products", token);
                    return Results.Ok();
                })
            .AddEndpointFilter<ValidatorFilter<UpdateProductCommand>>();

        group
            .MapDelete("/{productId:guid}",
                async ([FromRoute] Guid productId, IOutputCacheStore cache, CancellationToken token) =>
                {
                    await cache.EvictByTagAsync("Products", token);
                    return Results.Ok();
                })
            .CacheOutput(p => p.NoCache());

        return group;
    }
}