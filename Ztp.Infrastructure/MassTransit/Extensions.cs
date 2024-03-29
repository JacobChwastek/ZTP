﻿using System.Net;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Ztp.Application.Customers.Commands;
using MassTransit;
using Ztp.Application.Customers.Queries;

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
                cfg.ConfigureJsonSerializerOptions(opt =>
                {
                    opt.IncludeFields = true;
                    return opt;
                });
                
                var url = EncodeRabbitMqUrl(configuration["Messaging:RabbitMQ:Url"]);
                cfg.Host(url);
                cfg.ConfigureEndpoints(context);
            });

            c.AddMediator(cfg =>
            {
                cfg.AddConsumers(typeof(GetCustomerQueryHandler).Assembly);
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