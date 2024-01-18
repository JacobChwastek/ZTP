using JasperFx.CodeGeneration;
using Marten;
using Marten.Events.Daemon.Resiliency;
using Marten.Events.Projections;
using Marten.Services.Json;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Weasel.Core;
using Ztp.Domain.Contracts.v0.AggregateIdentities;
using Ztp.Domain.Customers;
using Ztp.Domain.Orders;
using Ztp.Domain.Products;
using Ztp.Shared.Abstractions.Marten;
using Ztp.Shared.Abstractions.Marten.Aggregate;
using Ztp.Shared.Abstractions.OptimisticConcurrency;
using Ztp.Shared.Contracts;

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

                options.Projections.Snapshot<Customer>(SnapshotLifecycle.Inline);
                    // options.Projections.Snapshot<Order>(SnapshotLifecycle.Inline);
                    // options.Projections.Snapshot<Product>(SnapshotLifecycle.Inline);
            })
            .ApplyAllDatabaseChangesOnStartup()
            .OptimizeArtifactWorkflow(TypeLoadMode.Static)
            .UseLightweightSessions()
            .AddAsyncDaemon(DaemonMode.Solo);

        services.AddScoped<IExpectedResourceVersionProvider, ExpectedResourceVersionProvider>();
        services.AddScoped<INextResourceVersionProvider, NextResourceVersionProvider>();

        services.AddMartenRepository<Order, OrderId>();
        services.AddMartenRepository<Product, ProductId>();
        services.AddMartenRepository<Customer, CustomerId>();

        return services;
    }

    private static IServiceCollection AddMartenRepository<T, TKey>(this IServiceCollection services)
        where T : class, IAggregate<TKey> where TKey : StronglyTypedValue<Guid>
    {
        services.AddScoped<IMartenRepository<T>, MartenRepository<T, TKey>>();

        return services;
    }
}