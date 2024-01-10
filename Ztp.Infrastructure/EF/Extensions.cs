using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Ztp.Infrastructure.EF.Configuration;

namespace Ztp.Infrastructure.EF;

public static class Extensions
{
    public static IServiceCollection AddEf(this IServiceCollection services, IConfiguration configuration)
    {
        var options = configuration.GetSection("Cosmos").Get<CosmosOptions>();

        var connectionString = options!.ConnectionString;
        var databaseName = options!.DatabaseName;
        
        services.AddDbContext<LabDbContext>(context =>
        {
            context.UseCosmos(connectionString, databaseName);
            context.EnableSensitiveDataLogging();
        });

        return services;
    }
}