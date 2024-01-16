using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OutputCaching;
using Ztp.Api.Filters;
using Ztp.Application.Dto;
using Ztp.Application.Products.Commands.CreateProduct;
using Ztp.Application.Products.Commands.UpdateProduct;

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
            .MapGet("/", async () =>
            {
                // var products = await queryDispatcher.QueryAsync(new GetProductsQuery());
                return Results.Ok();
            })
            .CacheOutput(builder => builder.Tag("Products"))
            .Produces(StatusCodes.Status200OK, typeof(IReadOnlyList<ProductDto>))
            .Produces(StatusCodes.Status404NotFound, typeof(EmptyResult));

        group
            .MapGet("/{productId:guid}",
                async ([FromRoute] Guid productId) =>
                {
                    // var product = await queryDispatcher.QueryAsync(new GetProductQuery
                    // {
                    //     ProductId = productId
                    // });

                    return Results.Ok();
                })
            .CacheOutput(p =>
            {
                p.SetVaryByQuery(["productId"]);
                p.Tag("Products");
            });

        group
            .MapPost("/",
                async ([FromBody] CreateProductCommand createProduct, IOutputCacheStore cache, CancellationToken token) =>
                {
                    await cache.EvictByTagAsync("Products", token);
                    return Results.Ok();
                })
            .AddEndpointFilter<ValidatorFilter<CreateProductCommand>>();

        group
            .MapPut("/",
                async ([FromBody] UpdateProductCommand updateProduct, IOutputCacheStore cache, CancellationToken token) =>
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