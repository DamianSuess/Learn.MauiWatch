using System;
using Learn.MauiWatchMobile.Interfaces;
using Learn.MauiWatchMobile.Models;
using Microsoft.Extensions.Logging;

namespace Learn.MauiWatchMobile.Services;

/// <summary>Cross-platform wearable service use to access Android Wear and Apple Watch.</summary>
public class WearableService
{
  private readonly ILogger<WearableService> _log;
  private readonly IWatchService _watch;

  public WearableService(ILogger<WearableService> log, IWatchService watchService)
  {
    _log = log;

    _watch = watchService;
    _watch.ResponseReceived += OnWatchResponseReceived;
  }

  public IWatchService WatchService => _watch;

  public void Connect()
  {
    // Connect to watch
    _watch.Connect();
  }

  /// <summary>Send message to watch.</summary>
  /// <remarks>TODO: Use CommandType and payloads</remarks>
  public void SendMessage(CommandType cmdType, string payload)
  {
    // Send command to watch
    // Use CommandTypes here to get specific
    _watch.SendMessageAsync(cmdType, payload);
  }

  private void OnWatchResponseReceived(object sender, ResponseEventArgs e)
  {
    // YAY we got something!
    // Use MessagingCenter to report it
    _log.LogInformation("Client received response from watch. Display it!.");

    System.Diagnostics.Debugger.Break();
  }
}
