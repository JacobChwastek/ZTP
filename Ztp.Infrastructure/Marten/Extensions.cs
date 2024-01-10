using Marten;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Ztp.Infrastructure.Marten;

public static class Extensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        // var options = configuration.GetSection("Cosmos").Get<CosmosOptions>();
        
        services.AddMarten(options =>
        {
            // Establish the connection string to your Marten database
            // options.Connection(builder.Configuration.GetConnectionString("Marten")!);
        
            // If we're running in development mode, let Marten just take care
            // of all necessary schema building and patching behind the scenes
            // if (builder.Environment.IsDevelopment())
            // {
            //     options.AutoCreateSchemaObjects = AutoCreate.All;
            // }
        });
        return services;
    }
}