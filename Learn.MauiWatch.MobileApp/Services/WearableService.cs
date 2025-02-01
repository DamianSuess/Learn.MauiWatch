using System;
using Learn.MauiWatchMobile.Interfaces;
using Learn.MauiWatchMobile.Models;

namespace Learn.MauiWatchMobile.Services;

/// <summary>Cross-platform wearable service use to access Android Wear and Apple Watch.</summary>
public class WearableService
{
  private readonly IWatchService _watch;

  public WearableService(IWatchService watchService)
  {
    _watch = watchService;
    _watch.ResponseReceived += OnWatchResponseReceived;
  }

  public IWatchService WatchService => _watch;

  public void Connect()
  {
    // Connect to watch
    _watch.Connect();
  }

  public void SendMessage()
  {
    // Send command to watch
    _watch.SendMessageAsync("GetStatus");
  }

  private void OnWatchResponseReceived(object sender, ResponseEventArgs e)
  {
    throw new NotImplementedException();
  }
}
