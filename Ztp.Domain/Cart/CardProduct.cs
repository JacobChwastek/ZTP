using Ztp.Domain.Contracts.v0.AggregateIdentities;

namespace Ztp.Domain.Cart;

public class CardProduct
{
    public ProductId ProductId { get; private set; }
    public int Quantity { get; private set; }
        
    public CardProduct(ProductId product, int quantity)
    {

        if (quantity < 1)
        {
            throw new ArgumentOutOfRangeException(nameof(quantity));
        }

        Quantity = quantity;
    }

    public void IncreaseQuantity() => Quantity++;
    public void DecreaseQuantity()
    {
        if (Quantity - 1 < 0)
        {
            // throw new InvalidCartProductQuantityException();
        }

        Quantity--;
    }
}