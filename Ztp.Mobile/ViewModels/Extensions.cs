namespace Ztp.Mobile.ViewModels;

public static class Extensions
{
    public static MauiAppBuilder RegisterViewModels(this MauiAppBuilder builder)
    {
        builder.Services.AddTransient<ProductListViewModel>();
        return builder;
    }
}