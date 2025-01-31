using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Learn.MauiWatchMobile.Interfaces;
using Microsoft.Extensions.Logging;
using Android.Gsm.Wearable;

namespace Learn.MauiWatchMobile.Platforms.Android.Services;

public class WatchService : IWatchService
{
  private readonly ILogger<WatchService> _log;

  public WatchService(ILogger<WatchService> logger)
  {
    _log = logger;
    Initialize();
  }

  public void Connect()
  {
  }

  public void Disconnect()
  {
  }

  public void Initialize()
  {
    var msgClient = WearableClass

    Connect();
    // MessageReceived += OnMessageReceived(IWatchPacket packet)
  }

  public void ProcessResponse()
  {
  }

  public void SendMessage(string command, string payload)
  {
  }
}
