namespace Ztp.Mobile;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
    }
    
    private async void OnNavigateToProductsList(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("///ProductListView");
    }
}