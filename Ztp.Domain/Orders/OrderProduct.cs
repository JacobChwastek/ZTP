namespace Ztp.Domain.Orders;

public record OrderProduct
{
    private OrderProduct() { }
    
    public OrderProduct(Guid productId, int quantity, decimal unitPrice)
    {
        Id = productId;
        Quantity = quantity;
        UnitPrice = unitPrice;
    }
    
    public Guid Id { get; init; }
    public int Quantity { get; init; }
    public decimal UnitPrice { get; init; }

    public decimal TotalCost => Quantity * UnitPrice;
}