using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using Ztp.Mobile.Services;
using Ztp.Mobile.ViewModels;

namespace Ztp.Mobile;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        
        builder
            .UseMauiApp<App>()
            .UseMauiCommunityToolkit()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            })
            .RegisterAppServices()
            .RegisterViewModels();
        
#if DEBUG
        builder.Logging.AddDebug();
#endif

        var app = builder.Build();

        ServiceHelper.Initialize(app.Services);
        
        return app;
    }
}