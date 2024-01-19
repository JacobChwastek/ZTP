using System.Linq.Expressions;
using MassTransit;
using Ztp.Domain.Contracts.v0.Products.Events;

namespace Ztp.Domain.Products;

public class ProductSaga(IPublishEndpoint publishEndpoint) : Observes<ProductReservedForCart, ProductSaga>
{
    private readonly IPublishEndpoint _publishEndpoint = publishEndpoint;

    public Guid CorrelationId { get; set; }

    public async Task Consume(ConsumeContext<ProductReservedForCart> context)
    {
        // _publishEndpoint()
    }

    public Expression<Func<ProductSaga, ProductReservedForCart, bool>> CorrelationExpression => (saga, message) => saga.CorrelationId == message.Identifier;
}