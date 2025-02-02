using Learn.MauiWatchMobile.ViewModels;
using Microsoft.Maui.Controls;

namespace Learn.MauiWatchMobile;

public partial class MainPage : ContentPage
{
  public MainPage(MainViewModel viewModel)
  {
    InitializeComponent();
    BindingContext = viewModel;
  }
}
