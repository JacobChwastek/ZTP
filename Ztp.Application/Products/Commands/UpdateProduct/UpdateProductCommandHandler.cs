using Ztp.Domain.Products;
using Ztp.Domain.Shared;
using Ztp.Shared.Abstractions.Commands;
using Ztp.Shared.Abstractions.Marten;

namespace Ztp.Application.Products.Commands.UpdateProduct;

public class UpdateProductCommandHandler : ICommandHandler<UpdateProductCommand>
{
    private readonly IMartenRepository<Product> _repository;

    public UpdateProductCommandHandler(IMartenRepository<Product> repository)
    {
        _repository = repository;
    }

    public async Task HandleAsync(UpdateProductCommand command)
    {
        // await _repository.GetAndUpdate(command.Id, product =>
        // {
        //     product.Update(
        //         command.Name,
        //         command.Description,
        //       new Money(command.Price, command.Currency),
        //         command.Quantity
        //     );
        // });
    }
}