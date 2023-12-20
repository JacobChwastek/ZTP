using System.Text.Json.Serialization;

namespace Ztp.Web.Models;

public class Product
{
    [JsonPropertyName("productId")]
    public Guid ProductId { get; set; }
    
    [JsonPropertyName("createdAt")]
    public DateTime CreatedAt { get; set; }

    [JsonPropertyName("updateAt")]
    public DateTime UpdatedAt { get; set; }
    
    [JsonPropertyName("version")]
    public int Version { get; set; }
    
    [JsonPropertyName("details")]
    public ProductDetails ProductDetails { get; set; }
}