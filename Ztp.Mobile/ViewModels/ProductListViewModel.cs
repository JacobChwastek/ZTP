using System.Collections.ObjectModel;
using System.Windows.Input;
using Ztp.Mobile.Models;
using Ztp.Mobile.Services;
using Ztp.Mobile.Views;

namespace Ztp.Mobile.ViewModels;

public class ProductListViewModel: ViewModelBase
{
    private readonly IProductService _productService;
    public ObservableCollection<Product> Products { get; private set; }
    public ICommand LoadProductsCommand { get; }
    public ICommand DeleteCommand { get; }
    public ICommand EditCommand { get; }
    public ICommand DetailCommand { get; }
    public ICommand AddCommand { get; }
    
    public ProductListViewModel()
    {
        _productService = ServiceHelper.GetService<IProductService>();
        Products = [];
        
        LoadProductsCommand = new Command(async () => await LoadProducts());
        DeleteCommand = new Command<Product>(OnDelete);
        EditCommand = new Command<Product>(OnEdit);
        DetailCommand = new Command<Product>(OnDetail);
        AddCommand = new Command(AddProduct);
    }

    public async Task LoadProducts()
    {
        var products = await _productService.GetProductsAsync();
        
        Products.Clear();
        
        foreach (var product in products)
        {
            Products.Add(product);
        }
    }

    
    private async void OnDelete(Product product)
    {
        await _productService.DeleteProductAsync(product.ProductId);

        Products.Remove(product);
    }

    private async void AddProduct()
    {
        var route = $"////ProductAddView";
        await Shell.Current.GoToAsync(route);
    }

    private async void OnEdit(Product product)
    {
        if (product == null)
            return;

        var route = $"////ProductDetailView?productId={product.ProductId}";
        await Shell.Current.GoToAsync(route);
    }

    private async void OnDetail(Product product)
    {
        if (product == null)
            return;

        var route = $"////ProductDetailView?productId={product.ProductId}";
        await Shell.Current.GoToAsync(route);
      
    }
}