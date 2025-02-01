using Android;
using Android.App;
using Android.Content.PM;
using Android.Gms.Wearable;
using Android.OS;
using Learn.MauiWatchMobile.Platforms.Android.Services;
using Learn.MauiWatchMobile.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Maui;
using Microsoft.Maui.ApplicationModel;

namespace Learn.MauiWatchMobile;

[Activity(
  Theme = "@style/Maui.SplashTheme",
  MainLauncher = true,
  LaunchMode = LaunchMode.SingleTop,
  ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize | ConfigChanges.Density)]
public class MainActivity : MauiAppCompatActivity
{
  public static MainActivity? Instance;

  protected override void OnCreate(Bundle? savedInstanceState)
  {
    base.OnCreate(savedInstanceState);

    Platform.Init(this, savedInstanceState);

    var permission = Manifest.Permission.ActivityRecognition;
    if (Platform.AppContext.CheckSelfPermission(permission) != Permission.Granted)
    {
      // 1000 == myPermissionRequestCode
      RequestPermissions(new string[] { permission }, requestCode: 1000);
    }

    Instance = this;
  }

  protected override void OnResume()
  {
    base.OnResume();

    // Obsolete: Use, IPlatformApplication.Current.Services
    ////var service = IPlatformApplication.Current?.Services.GetService<WearableService>();

    var service = MainApplication.Current.Services.GetService<WearableService>();
    if (service != null)
    {
      // In case separation is needed:
      // var handler = service.WatchService.PlatformHandler as PlatformWatchHandler;
      var handler = service.WatchService as WatchService;

      WearableClass.GetDataClient(MainApplication.Current)
                   .AddListener(handler);

      WearableClass.GetMessageClient(MainApplication.Current)
                   .AddListener(handler);

      WearableClass.GetCapabilityClient(MainApplication.Current)
                   .AddListener(handler, WatchService.CAPABILITY_SUESSLABS_WEAR);
    }
  }
}
