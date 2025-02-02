using System.Windows.Input;
using Microsoft.Maui.Controls;

namespace Learn.MauiWatchMobile.ViewModels;

public class MainViewModel : BaseViewModel
{
  private int _count = 0;
  private string _watchMessage = string.Empty;

  public MainViewModel()
  {
  }

  public string WatchMessage
  {
    get => _watchMessage;
    set => SetProperty(ref _watchMessage, value);
  }

  public ICommand CmdSendMessage => new Command((obj) =>
  {
    _count++;
    WatchMessage = $"Sending {_count}...";
  });
}
