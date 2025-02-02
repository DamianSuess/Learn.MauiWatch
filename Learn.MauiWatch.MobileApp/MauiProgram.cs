using Learn.MauiWatchMobile.Interfaces;
using Learn.MauiWatchMobile.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Maui.Controls.Hosting;
using Microsoft.Maui.Hosting;
using Learn.MauiWatchMobile.Services;

#if ANDROID

using Learn.MauiWatchMobile.Platforms.Android.Services;

#endif

namespace Learn.MauiWatchMobile;

public static class MauiProgram
{
  public static MauiApp CreateMauiApp()
  {
    var builder = MauiApp.CreateBuilder();
    builder
      .UseMauiApp<App>()
      .ConfigureFonts(fonts =>
      {
        fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
        fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
      });

#if DEBUG
    builder.Logging.AddDebug();
#endif

    builder.Services.AddSingleton<WearableService>();

#if ANDROID
    builder.Services.AddSingleton<IWatchService, WatchService>();
#elif IOS
    // builder.Services.AddSingleton<IWatchService, WatchService>();
#endif

    builder.Services.AddTransient<MainViewModel>();
    builder.Services.AddTransient<MainPage>();

    return builder.Build();
  }
}
