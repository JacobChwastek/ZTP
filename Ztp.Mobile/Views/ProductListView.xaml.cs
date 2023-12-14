using Ztp.Mobile.ViewModels;

namespace Ztp.Mobile.Views;

public partial class ProductListView :  ContentPage
{
    public ProductListView()
    {
        InitializeComponent();
    }    
    
    protected override async void OnAppearing()
    {
        base.OnAppearing();

        if (BindingContext is ProductListViewModel viewModel)
        {
            viewModel.LoadProductsCommand.Execute(null);
        }
    }

    protected override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);
        
        if (BindingContext is ProductListViewModel viewModel)
        {
            viewModel.LoadProductsCommand.Execute(null);
        }
    }
}