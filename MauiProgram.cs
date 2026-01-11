using CommunityToolkit.Maui;
using MIPProiect02.Services;
using MIPProiect02.ViewModels;
using MIPProiect02.Views;

namespace MIPProiect02;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .UseMauiCommunityToolkit()
            .ConfigureFonts(fonts => {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
            });

        builder.Services.AddSingleton<DatabaseService>();
        builder.Services.AddSingleton<MainViewModel>();
        builder.Services.AddSingleton<MainPage>();
        builder.Services.AddTransient<TaskDetailViewModel>();
        builder.Services.AddTransient<TaskDetailPage>();

        return builder.Build();
    }
}