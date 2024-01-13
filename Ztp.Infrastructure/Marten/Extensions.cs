using JasperFx.CodeGeneration;
using Marten;
using Marten.Events.Daemon.Resiliency;
using Marten.Events.Projections;
using Marten.Services.Json;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Weasel.Core;
using Ztp.Domain.Customers;
using Ztp.Domain.Orders;
using Ztp.Domain.Products;
using Ztp.Infrastructure.Marten.Repositories;
using Ztp.Shared.Abstractions.Aggregate;
using Ztp.Shared.Abstractions.Marten;
using Ztp.Shared.Abstractions.OptimisticConcurrency;

namespace Ztp.Infrastructure.Marten;

public static class Extensions
{
    public static IServiceCollection AddMarten(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddMarten(options =>
            {
                options.Connection(configuration.GetConnectionString("EventStore")!);
                options.AutoCreateSchemaObjects = AutoCreate.All;
                options.UseDefaultSerialization(
                    EnumStorage.AsString,
                    nonPublicMembersStorage: NonPublicMembersStorage.All,
                    serializerType: SerializerType.SystemTextJson
                );
                
                options.Projections.Snapshot<Order>(SnapshotLifecycle.Inline);
                options.Projections.Snapshot<Product>(SnapshotLifecycle.Inline);
                options.Projections.Snapshot<Customer>(SnapshotLifecycle.Inline);
            })
            .ApplyAllDatabaseChangesOnStartup()
            .OptimizeArtifactWorkflow(TypeLoadMode.Static)
            .UseLightweightSessions()
            .AddAsyncDaemon(DaemonMode.Solo);

        services.AddScoped<IExpectedResourceVersionProvider, ExpectedResourceVersionProvider>();
        services.AddScoped<INextResourceVersionProvider, NextResourceVersionProvider>();
        
        services.AddMartenRepository<Order>();
        services.AddMartenRepository<Product>();
        services.AddMartenRepository<Customer>();

        return services;
    }

    public static IServiceCollection AddMartenRepository<T>(this IServiceCollection services,bool withAppendScope = true) where T : class, IAggregate
    {
        services.AddScoped<IMartenRepository<T>, MartenRepository<T>>();

        if (withAppendScope)
            services.Decorate<IMartenRepository<T>>(
                (inner, sp) => new MartenRepositoryWithETagDecorator<T>(
                    inner,
                    sp.GetRequiredService<IExpectedResourceVersionProvider>(),
                    sp.GetRequiredService<INextResourceVersionProvider>()
                )
            );
        
        return services;
    }
}