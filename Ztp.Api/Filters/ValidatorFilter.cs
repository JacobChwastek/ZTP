using FluentValidation;

namespace Ztp.Api.Filters;

public class ValidatorFilter<T>(IValidator<T> validator) : IEndpointFilter
{
    public async ValueTask<object?> InvokeAsync(EndpointFilterInvocationContext context, EndpointFilterDelegate next)
    {
        var argument = context.GetArgument<T>(0);
        var validationResult = await validator.ValidateAsync(argument);

        if (validationResult.IsValid)
        {
            return await next(context);
        }

        return Results.BadRequest(validationResult.Errors.Select(x => x.ErrorMessage));
    }
}