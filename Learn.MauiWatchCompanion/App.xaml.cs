using Microsoft.Maui.Controls;

namespace Learn.MauiWatchCompanion;

public partial class App : Application
{
  public App()
  {
    InitializeComponent();

    MainPage = new AppShell();
  }
}
