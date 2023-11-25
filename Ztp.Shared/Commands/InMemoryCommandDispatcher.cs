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

    public async Task<TResult> DispatchAsync<TCommand, TResult>(TCommand command) where TCommand : class, ICommand
    {
        using var scope = serviceProvider.CreateScope();
        var handlerType = typeof(ICommandHandler<,>).MakeGenericType(command.GetType(), typeof(TResult));
        var handler = scope.ServiceProvider.GetRequiredService(handlerType);

        return await (Task<TResult>)handlerType
            .GetMethod(nameof(ICommandHandler<ICommand<TResult>, TResult>.HandleAsync))?
            .Invoke(handler, new[] { command });
    }
}