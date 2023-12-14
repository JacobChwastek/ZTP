using System.Text.Json.Serialization;

namespace Ztp.Mobile.Models;

public class ProductDetails
{
    [JsonPropertyName("name")]
    public string Name { get; set; }
    
    [JsonPropertyName("description")]
    public string Description { get; set; }
    
    [JsonPropertyName("quantity")]
    public int Quantity { get; set; }
    
    [JsonPropertyName("price")]
    public Money Price { get; set; }
    
    [JsonPropertyName("availability")]
    public bool Availability { get; set; }
}

public class Money
{
    [JsonPropertyName("amount")]
    public decimal Amount { get; set; }
    
    [JsonPropertyName("currency")]
    public string Currency { get; set;  }
}
