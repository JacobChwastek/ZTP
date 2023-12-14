using System.Windows.Input;
using Ztp.Mobile.Models;
using Ztp.Mobile.Services;
using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;

namespace Ztp.Mobile.ViewModels;

public class ProductAddViewModel : ViewModelBase
{
    private readonly IProductService _productService;
    private CreateProduct _selectedProduct;
    public CreateProduct SelectedProduct
    {
        get => _selectedProduct;
        set => SetProperty(ref _selectedProduct, value);
    }

    public ICommand AddProductCommand { get; }

    public ProductAddViewModel()
    {
        SelectedProduct = new CreateProduct();
        _productService = ServiceHelper.GetService<IProductService>();
        AddProductCommand = new Command(AddProduct);
        
    }
    
    private async void AddProduct()
    {
        try
        {
            await _productService.AddProductAsync(SelectedProduct);
            const string text = "Product created";

            var toast = Toast.Make(text);
            
            await toast.Show(CancellationToken.None);
            await Shell.Current.GoToAsync("///ProductListView");
        }
        catch (Exception)
        {
            const string text = "Product not created";

            var toast = Toast.Make(text);
            
            await toast.Show(CancellationToken.None);
        }
    }
}