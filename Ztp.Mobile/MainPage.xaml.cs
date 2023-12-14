using Ztp.Mobile.Views;

namespace Ztp.Mobile;

public partial class MainPage : ContentPage
{
    int count = 0;

    public MainPage()
    {
        InitializeComponent();
    }
    
    private async void OnNavigateToProductsList(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("///ProductListView");
    }
}