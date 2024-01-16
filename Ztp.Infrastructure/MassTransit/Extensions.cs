using System.Net;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Ztp.Application.Customers.Commands;
using MassTransit;

namespace Ztp.Infrastructure.MassTransit;

public static class Extensions
{
    public static IServiceCollection AddMessageBus(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddMassTransit(c =>
        {
            c.AddConsumers(typeof(CreateCustomerCommandConsumer).Assembly);

            c.UsingRabbitMq((context, cfg) =>
            {
                var url = EncodeRabbitMqUrl(configuration["Messaging:RabbitMQ:Url"]);
                cfg.Host(url);
                cfg.ConfigureEndpoints(context);
            });
        });

        return services;
    }

    private static Uri EncodeRabbitMqUrl(string connectionString)
    {
        var split = connectionString.Split(new[] { "://", "@" }, StringSplitOptions.RemoveEmptyEntries);
        var credentials = split[1].Split(':');

        var encodedConnectionString =
            $"{split[0]}://{WebUtility.UrlEncode(credentials[0])}:{WebUtility.UrlEncode(credentials[1])}@{split[2]}";

        return new Uri(encodedConnectionString);
    }
}