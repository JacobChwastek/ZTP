using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OutputCaching;
using Ztp.Api.Filters;
using Ztp.Application.Commands.CreateProduct;
using Ztp.Application.Commands.DeleteProduct;
using Ztp.Application.Commands.UpdateProduct;
using Ztp.Application.Queries.GetProduct;
using Ztp.Application.Queries.GetProducts;
using Ztp.Shared.Abstractions.Commands;
using Ztp.Shared.Abstractions.Queries;

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
            .MapGet("/", async (IQueryDispatcher queryDispatcher) =>
            {
                var products = await queryDispatcher.QueryAsync(new GetProductsQuery());
                return Results.Ok(products);
            })
            .CacheOutput(builder => builder.Tag("Products"));

        group
            .MapGet("/{productId:guid}",
                async ([FromRoute] Guid productId, IQueryDispatcher queryDispatcher) =>
                {
                    var product = await queryDispatcher.QueryAsync(new GetProductQuery
                    {
                        ProductId = productId
                    });

                    return Results.Ok(product);
                })
            .CacheOutput(p =>
            {
                p.SetVaryByQuery(["productId"]);
                p.Tag("Products");
            });

        group
            .MapPost("/",
                async ([FromBody] CreateProductCommand createProduct, ICommandDispatcher commandDispatcher,
                    IOutputCacheStore cache, CancellationToken token) =>
                {
                    var productId = await commandDispatcher.DispatchAsync<CreateProductCommand, Guid>(createProduct);

                    await cache.EvictByTagAsync("Products", token);
                    return Results.Created($"api/products/{productId}", createProduct);
                })
            .AddEndpointFilter<ValidatorFilter<CreateProductCommand>>();

        group
            .MapPut("/",
                async ([FromBody] UpdateProductCommand updateProduct, ICommandDispatcher commandDispatcher,
                    IOutputCacheStore cache, CancellationToken token) =>
                {
                    await commandDispatcher.DispatchAsync(updateProduct);
                    await cache.EvictByTagAsync("Products", token);
                    return Results.Ok();
                })
            .AddEndpointFilter<ValidatorFilter<UpdateProductCommand>>();

        group
            .MapDelete("/{productId:guid}",
                async ([FromRoute] Guid productId, ICommandDispatcher commandDispatcher, IOutputCacheStore cache, CancellationToken token) =>
                {
                    await commandDispatcher.DispatchAsync(new DeleteProductCommand(productId));
                    await cache.EvictByTagAsync("Products", token);
                    return Results.Ok();
                })
            .CacheOutput(p => p.NoCache());

        return group;
    }
}