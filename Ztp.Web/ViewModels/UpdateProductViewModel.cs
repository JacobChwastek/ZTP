using System.ComponentModel.DataAnnotations;
using Ztp.Web.Models;

namespace Ztp.Web.ViewModels;

public class UpdateProductViewModel
{
    public UpdateProductViewModel()
    {
        
    }
    public UpdateProductViewModel(Product product)
    {
        Id = product.ProductId;
        Name = product.ProductDetails.Name;
        Description = product.ProductDetails.Description;
        Price = product.ProductDetails.Price.Amount;
        Quantity = product.ProductDetails.Quantity;

        var currency = Enum.Parse<Currency>(product.ProductDetails.Price.Currency);
        Currency = (int)currency;
    }

    [Required]
    public Guid Id { get; set; }

    [Required]
    public string? Name { get; set; }
    
    [Required]
    public string? Description { get; set; }

    [Required]
    [DataType(DataType.Currency)]
    public decimal? Price { get; set; } = 0.0m;
    
    [Required]
    public int Quantity { get; set; }

    [Required]
    public int Currency { get; set; }
}