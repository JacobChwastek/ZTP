using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Ztp.Domain.Repositories;
using Ztp.Infrastructure.EF;
using Ztp.Infrastructure.EF.Configuration;
using Ztp.Infrastructure.Repositories;

namespace Ztp.Infrastructure;

public static class Extensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var options = configuration.GetSection("Cosmos").Get<CosmosOptions>();

        var connectionString = options!.ConnectionString;
        var databaseName = options!.DatabaseName;
        
        services.AddDbContext<LabDbContext>(context =>
        {
            context.UseCosmos(connectionString, databaseName);
            context.EnableSensitiveDataLogging();
        });
        
        services.AddScoped<IProductRepository, ProductRepository>();
        
        return services;
    }
}