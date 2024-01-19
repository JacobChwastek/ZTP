using Ztp.Domain.Contracts.v0.AggregateIdentities;
using Ztp.Shared.Contracts;

namespace Ztp.Domain.Contracts.v0.Products.Events;

public class ProductOutOfStock : Event<ProductId>
{
    private ProductOutOfStock()
    {
    }   
    
    public ProductOutOfStock(ProductId identifier, int availableQuantity, int requestedQuantity) : base(identifier)
    {
        AvailableQuantity = availableQuantity;
        RequestedQuantity = requestedQuantity;
    }

    public int AvailableQuantity { get; private set; }
    public int RequestedQuantity { get; private set; }
}