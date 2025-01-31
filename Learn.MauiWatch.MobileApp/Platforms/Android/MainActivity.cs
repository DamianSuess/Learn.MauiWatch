using Android;
using Android.App;
using Android.Content.PM;
using Android.OS;
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

    /*
    var wearableService = MainApplication.Current.Services.GetService<WearableInteractionService>();
    if (wearableService != null)
    {
      var handler = wearablesService.Handler as WatchService.PlatformHanlder)
    }
    */
  }
}
