using FluentValidation;
using Ztp.Domain.Products;
using Ztp.Shared.Abstractions.Commands;

namespace Ztp.Application.Commands.CreateProduct;

public class CreateProductCommand(string name, string description, decimal price, Currency currency, int quantity) : ICommand<Guid>
{
    public string Name { get; } = name;
    public string Description { get; } = description;
    public decimal Price { get; } = price;
    public int Quantity { get; } = quantity;
    public Currency Currency { get; } = currency;
}

public class CreateProductValidator : AbstractValidator<CreateProductCommand>
{
    public CreateProductValidator()
    {
        RuleFor(x => x.Name).NotEmpty().NotNull().MaximumLength(256);
        RuleFor(x => x.Description).NotEmpty().NotNull().MaximumLength(500);
        RuleFor(x => x.Price).LessThan(10000).GreaterThanOrEqualTo(0);
        RuleFor(x => x.Quantity).GreaterThanOrEqualTo(0);
        RuleFor(x => x.Currency).NotEmpty().NotNull();
        RuleFor(x => x.Currency).Must(i => Enum.IsDefined(typeof(Currency), i)).WithMessage(_ => "Not supported currency");
    }
}