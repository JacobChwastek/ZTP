
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Ztp.Domain.Products;
using Ztp.Infrastructure.EF;
using Ztp.Infrastructure.Repositories;

namespace Ztp.Infrastructure;

public static class Extensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddEf(configuration);
        
        services.AddScoped<IProductRepository, ProductRepository>();
        
        return services;
    }
}