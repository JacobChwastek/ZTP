using Ztp.Domain.Contracts.v0.AggregateIdentities;
using Ztp.Shared.Abstractions.Marten.Aggregate;

namespace Ztp.Domain.Cart;

public class Cart : Aggregate<CartId>
{
    private Cart()
    {
    }

    private Cart(CartId id)
    {
        // var @event = new CartCreated(id);
    }

    private static Cart New()
    {
        return new Cart(new CartId(Guid.NewGuid()));
    }
    
    
    
    public void AddProduct()
    {
        // var @event = new 
    }
    
    public void RemoveProduct()
    {
    }

    public void Clear()
    {
        
    }

    public void Checkout()
    {
        
    }
}