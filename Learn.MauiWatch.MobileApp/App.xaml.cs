using Learn.MauiWatchMobile.Services;
using Microsoft.Maui.Controls;

namespace Learn.MauiWatchMobile;

public partial class App : Application
{
  private readonly WearableService _wearable;

  public App(WearableService wearable)
  {
    InitializeComponent();

    _wearable = wearable;

    MainPage = new AppShell();
  }

  protected override void OnStart()
  {
    base.OnStart();
    _wearable.Connect();
  }

  protected override void OnSleep()
  {
    base.OnSleep();
  }

  protected override void OnResume()
  {
    base.OnResume();
    _wearable.Connect();
  }
}
