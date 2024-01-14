using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Ztp.Infrastructure.Marten;

namespace Ztp.Infrastructure;

public static class Extensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddMarten(configuration);

        return services;
    }
}