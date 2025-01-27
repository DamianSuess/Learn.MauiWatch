using Learn.MauiWatchCompanion.ViewModels;
using Microsoft.Maui.Controls;

namespace Learn.MauiWatchCompanion;

public partial class MainPage : ContentPage
{
  public MainPage(MainViewModel viewModel)
  {
    InitializeComponent();

    ViewModel = viewModel;
    BindingContext = viewModel;
  }

  public MainViewModel ViewModel { get; set; }
}
