using Ztp.Mobile.ViewModels;

namespace Ztp.Mobile.Views;

[QueryProperty(nameof(ProductId), "productId")]
public partial class ProductDetailsView : ContentPage
{
    private string _productId;
    public string ProductId
    {
        set
        {
            _productId = value;
            LoadProductDetails(value);
        }
        get => _productId;
    }
    
    public ProductDetailsView()
    {
        InitializeComponent();
        BindingContext = new ProductDetailsViewModel();
    }
    
    private void LoadProductDetails(string productIdString)
    {
        if (!Guid.TryParse(productIdString, out var productId)) return;
        if (BindingContext is ProductDetailsViewModel viewModel)
        {
            viewModel.LoadProductDetailsCommand.Execute(productId);
        }
    }
}