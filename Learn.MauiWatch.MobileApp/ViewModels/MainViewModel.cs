using System.Windows.Input;
using Learn.MauiWatchMobile.Services;
using Microsoft.Maui.Controls;

namespace Learn.MauiWatchMobile.ViewModels;

public class MainViewModel : BaseViewModel
{
  private readonly WearableService _wearable;
  private int _count = 0;
  private string _watchMessage = string.Empty;

  public MainViewModel(WearableService wearable)
  {
    _wearable = wearable;
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

    _wearable.SendMessage(Models.CommandType.Message, _count.ToString());
  });
}
