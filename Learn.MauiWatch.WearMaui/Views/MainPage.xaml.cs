using Learn.MauiWatch.WearMaui.ViewModels;
using Microsoft.Maui.Controls;

namespace Learn.MauiWatch.WearMaui;

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
