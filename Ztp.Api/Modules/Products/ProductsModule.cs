using Microsoft.AspNetCore.Mvc;
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
        endpoints.MapGet("api/products", async (IQueryDispatcher queryDispatcher) =>
        {
            var products = await queryDispatcher.QueryAsync(new GetProductsQuery());
            return Results.Ok(products);
        });

        endpoints.MapGet("api/products/{productId}",
            async ([FromRoute] Guid productId, IQueryDispatcher queryDispatcher) =>
            {
                var product = await queryDispatcher.QueryAsync(new GetProductQuery
                {
                    ProductId = productId
                });

                return Results.Ok(product);
            });

        endpoints.MapPost("api/products",
            async ([FromBody] CreateProductCommand createProduct, ICommandDispatcher commandDispatcher) =>
            {
                var productId = await commandDispatcher.DispatchAsync<CreateProductCommand, Guid>(createProduct);

                return Results.Created($"api/products/{productId}", createProduct);
            }).AddEndpointFilter<ValidatorFilter<CreateProductCommand>>();

        endpoints.MapPut("api/products",
                async ([FromBody] UpdateProductCommand updateProduct, ICommandDispatcher commandDispatcher) =>
                {
                    await commandDispatcher.DispatchAsync(updateProduct);

                    return Results.Ok();
                })
            .AddEndpointFilter<ValidatorFilter<UpdateProductCommand>>();

        endpoints.MapDelete("api/products/{productId}",
            async ([FromRoute] Guid productId, ICommandDispatcher commandDispatcher) =>
            {
                await commandDispatcher.DispatchAsync(new DeleteProductCommand(productId));
                return Results.Ok();
            });

        return endpoints;
    }
}