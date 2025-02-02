using System.Windows.Input;
using Learn.MauiWatchMobile.Models;
using Learn.MauiWatchMobile.Services;
using Microsoft.Maui.Controls;

namespace Learn.MauiWatchMobile.ViewModels;

public class MainViewModel : BaseViewModel
{
  private readonly WearableService _wearable;
  private int _sentCount = 0;
  private int _recvCount = 0;
  private string _sentMessage = string.Empty;
  private string _recvMessage = string.Empty;

  public MainViewModel(WearableService wearable)
  {
    _wearable = wearable;

    _wearable.WatchService.ResponseReceived += WatchService_ResponseReceived;
  }

  public string SentMessage { get => _sentMessage; set => SetProperty(ref _sentMessage, value); }

  public string RecvMessage { get => _recvMessage; set => SetProperty(ref _recvMessage, value); }

  public ICommand CmdSendMessage => new Command((obj) =>
  {
    _sentCount++;
    SentMessage = $"Sending {_sentCount}...";

    _wearable.SendMessage(Models.CommandType.Message, _sentCount.ToString());
  });

  private void WatchService_ResponseReceived(object sender, ResponseEventArgs e)
  {
    _recvCount++;
    RecvMessage = _recvCount.ToString();
  }
}
