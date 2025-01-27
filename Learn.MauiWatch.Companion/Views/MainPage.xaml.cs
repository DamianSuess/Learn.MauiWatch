using Learn.MauiWatch.Companion.ViewModels;
using Microsoft.Maui.Controls;

namespace Learn.MauiWatch.Companion;

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
