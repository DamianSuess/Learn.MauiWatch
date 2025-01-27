using Microsoft.Maui.Controls;

namespace Learn.MauiWatchMobile;

public partial class App : Application
{
  public App()
  {
    InitializeComponent();

    MainPage = new AppShell();
  }
}
