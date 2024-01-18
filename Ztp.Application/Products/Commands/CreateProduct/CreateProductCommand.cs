using FluentValidation;
using Ztp.Shared.Abstractions.Shared;

namespace Ztp.Application.Products.Commands.CreateProduct;

public record CreateProductCommand(string Name, string Description, decimal Amount, Currency Currency, int Quantity);
public class CreateProductValidator : AbstractValidator<CreateProductCommand>
{
    public CreateProductValidator()
    {
        // RuleFor(x => x.Name).NotNull().MaximumLength(256);
        // RuleFor(x => x.Description).NotNull().MaximumLength(500);
        // RuleFor(x => x.Amount).LessThan(15000).GreaterThanOrEqualTo(0);
        // RuleFor(x => x.Quantity).GreaterThanOrEqualTo(0).LessThan(20000);
        // RuleFor(x => x.Currency).NotEmpty().NotNull().Must(i => Enum.IsDefined(typeof(Currency), i));
    }
}