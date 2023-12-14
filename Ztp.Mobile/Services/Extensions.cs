namespace Ztp.Mobile.Services;

public static class Extensions
{
    public static MauiAppBuilder RegisterAppServices(this MauiAppBuilder builder)
    {
        builder.Services.AddSingleton<HttpClient>();
        builder.Services.AddSingleton<IProductService, ProductService>();
        
        return builder;
    }
}