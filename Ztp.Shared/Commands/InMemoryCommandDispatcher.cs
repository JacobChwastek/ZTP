using Ztp.Shared.Abstractions.Commands;
using Microsoft.Extensions.DependencyInjection;

namespace Ztp.Shared.Commands;

internal sealed class InMemoryCommandDispatcher(IServiceProvider serviceProvider) : ICommandDispatcher
{
    public async Task DispatchAsync<TCommand>(TCommand command) where TCommand : class, ICommand
    {
        using var scope = serviceProvider.CreateScope();
        var handlerType = typeof(ICommandHandler<>).MakeGenericType(command.GetType());
        var handler = scope.ServiceProvider.GetRequiredService(handlerType);

        await (Task)handlerType
            .GetMethod(nameof(ICommandHandler<ICommand>.HandleAsync))?
            .Invoke(handler, new[] { command });
    }
}