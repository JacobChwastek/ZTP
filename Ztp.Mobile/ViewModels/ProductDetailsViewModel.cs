using System.Windows.Input;
using Ztp.Mobile.Models;
using Ztp.Mobile.Services;

namespace Ztp.Mobile.ViewModels;

public class ProductDetailsViewModel : ViewModelBase
{
    private readonly IProductService _productService;
    private Product _selectedProduct;
    public Product SelectedProduct
    {
        get => _selectedProduct;
        set => SetProperty(ref _selectedProduct, value);
    }

    public ICommand LoadProductDetailsCommand { get; }
    public ICommand SaveCommand { get; }
    public ICommand BackCommand { get; }

    public ProductDetailsViewModel()
    {
        _productService = ServiceHelper.GetService<IProductService>();
        SaveCommand = new Command(SaveProduct);
        BackCommand = new Command(GoBack);
        LoadProductDetailsCommand = new Command<Guid>(LoadProduct);
    }

    public async void LoadProduct(Guid productId)
    {
        SelectedProduct = await _productService.GetProductAsync(productId);
    }
    
    private async void SaveProduct()
    {
        Enum.TryParse<Currency>(SelectedProduct.ProductDetails.Price.Currency, out var currency);
        await _productService.UpdateProductAsync(new UpdateProductRequest()
        {
            Currency = (int)currency,
            Description = SelectedProduct.ProductDetails.Description,
            Name = SelectedProduct.ProductDetails.Name,
            Price = SelectedProduct.ProductDetails.Price.Amount,
            Id = SelectedProduct.ProductId,
            Quantity = SelectedProduct.ProductDetails.Quantity
        });
        await Shell.Current.GoToAsync("///ProductListView");
    }

    private async void GoBack()
    {
        await Shell.Current.GoToAsync("///ProductListView");
    }
}