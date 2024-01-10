using Ztp.Shared.Commands;
using Ztp.Shared.Queries;
using Microsoft.Extensions.DependencyInjection;
using FluentValidation;
using Ztp.Application.Products.Commands.CreateProduct;

namespace Ztp.Application;

public static class Extensions
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddCommands();
        services.AddQueries();

        services.AddValidatorsFromAssemblyContaining<CreateProductValidator>();
        
        return services;
    }
}