using Learn.MauiWatch.WearMaui.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Maui.Controls.Hosting;
using Microsoft.Maui.Hosting;

namespace Learn.MauiWatch.WearMaui;

public static class MauiProgram
{
  public static MauiApp CreateMauiApp()
  {
    var builder = MauiApp.CreateBuilder();

    builder
      .UseMauiApp<App>()
      .RegisterServices()
      .RegisterViews()
      .ConfigureFonts(fonts =>
      {
        fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
        fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
      });

#if DEBUG
    builder.Logging.AddDebug();
#endif

    return builder.Build();
  }

  private static MauiAppBuilder RegisterServices(this MauiAppBuilder builder)
  {
    // Register Services:
    // builder.Services.AddSingleton<ISettingsService, SettingsService>();
    return builder;
  }

  private static MauiAppBuilder RegisterViews(this MauiAppBuilder builder)
  {
    // Register Views
    builder.Services.AddSingleton<MainViewModel>();
    return builder;
  }
}
