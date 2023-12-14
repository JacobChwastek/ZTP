using Ztp.Mobile.ViewModels;

namespace Ztp.Mobile.Views;

public partial class ProductAddView : ContentPage
{
    public ProductAddView()
    {
        InitializeComponent();
        BindingContext = new ProductAddViewModel();
    }
}