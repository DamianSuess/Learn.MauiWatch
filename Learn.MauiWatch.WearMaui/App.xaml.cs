using Microsoft.Maui.Controls;

namespace Learn.MauiWatch.WearMaui;

public partial class App : Application
{
  public App()
  {
    InitializeComponent();

    MainPage = new AppShell();
  }
}
