using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Ztp.Infrastructure.Marten;
using Ztp.Infrastructure.MassTransit;
using Ztp.Projections;

namespace Ztp.Infrastructure;

public static class Extensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddMarten(configuration);
        services.AddMessageBus(configuration);
        
        services.AddDbContext<ProjectionsDbContext>(options =>
        {
            options.UseNpgsql(configuration.GetConnectionString("Projections"));
        });


        return services;
    }
}