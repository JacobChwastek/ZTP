namespace Ztp.Api.Modules;

public static class Extensions
{
    private static readonly List<IApiModule> RegisteredModules = new();

    public static IServiceCollection AddApiModules(this IServiceCollection services)
    {
        var modules = typeof(IApiModule).Assembly
            .GetTypes()
            .Where(p => p.IsClass && p.IsAssignableTo(typeof(IApiModule)))
            .Select(Activator.CreateInstance)
            .Cast<IApiModule>();

        foreach (var module in modules)
        {
            RegisteredModules.Add(module);
        }

        return services;
    }

    public static WebApplication UseApiModules(this WebApplication app)
    {
        foreach (var module in RegisteredModules)
        {
            module.MapEndpoints(app);
        }

        return app;
    }
}