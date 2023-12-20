using System.ComponentModel.DataAnnotations;
using Ztp.Web.Models;

namespace Ztp.Web.ViewModels;

public class CreateProductViewModel
{
    public CreateProductViewModel()
    {
        
    }

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
    public int? Currency { get; set; } = 1;
}