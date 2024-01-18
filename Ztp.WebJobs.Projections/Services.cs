using MassTransit;
using Microsoft.EntityFrameworkCore;
using Ztp.Projections;
using Ztp.Projections.EventHandlers.Customers;

namespace Ztp.WebJobs.Projections;

public static class Services
{
    public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddMassTransit(c =>
        {
            c.AddConsumers(typeof(CustomerAddedEventHandler).Assembly);
            c.UsingRabbitMq((context,cfg) =>
            {
                cfg.ConfigureJsonSerializerOptions(opt =>
                {
                    opt.IncludeFields = true;   
                    return opt;
                });
                
                cfg.Host(configuration["Messaging:RabbitMQ:Host"], configuration["Messaging:RabbitMQ:VHost"], h => {
                    h.Username(configuration["Messaging:RabbitMQ:User"]);
                    h.Password(configuration["Messaging:RabbitMQ:Password"]);
                });

                cfg.ConfigureEndpoints(context);
            });
        });
        
        services.AddDbContext<ProjectionsDbContext>(options =>
        {
            options.UseNpgsql(configuration.GetConnectionString("Projections"));
        });
        
        services.AddHostedService<Worker>();
        
        return services;
    }
}