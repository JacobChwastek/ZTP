using MassTransit;
using Ztp.WebJobs.Domain;

var builder = Host.CreateApplicationBuilder(args);

builder.Services.AddMassTransit(c =>
{
    c.UsingRabbitMq((context,cfg) =>
    {
        cfg.ConfigureJsonSerializerOptions(opt =>
        {
            opt.IncludeFields = true;
            return opt;
        });
        
        cfg.Host(builder.Configuration["Messaging:RabbitMQ:Host"], builder.Configuration["Messaging:RabbitMQ:VHost"], h => {
            h.Username(builder.Configuration["Messaging:RabbitMQ:User"]);
            h.Password(builder.Configuration["Messaging:RabbitMQ:Password"]);
        });

        cfg.ConfigureEndpoints(context);
    });
});

builder.Services.AddHostedService<Worker>();

var host = builder.Build();
host.Run();