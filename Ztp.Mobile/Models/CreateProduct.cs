namespace Ztp.Mobile.Models;

public class CreateProduct
{
    private Currency _currency;
    
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public int Quantity { get; set; }

    public int Currency
    {
        get => (int)_currency;
        set => _currency = (Currency)value;
    }
}