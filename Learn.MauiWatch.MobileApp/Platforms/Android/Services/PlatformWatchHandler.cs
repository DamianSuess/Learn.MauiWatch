/*
using System;
using Android.Gms.Wearable;
using Learn.MauiWatchMobile.Interfaces;
using Microsoft.Extensions.Logging;
using Microsoft.Maui.ApplicationModel;

namespace Learn.MauiWatchMobile.Platforms.Android.Services;

/// <summary>Platform specific <see cref="WatchService"/> handlers.</summary>
public class PlatformWatchHandler :
  Java.Lang.Object,
  MessageClient.IOnMessageReceivedListener,
  DataClient.IOnDataChangedListener,
  CapabilityClient.IOnCapabilityChangedListener,
  IPlatformWatchHandler
{
  private readonly CapabilityClient _capabilityClient;
  private readonly ChannelClient _channelClient;
  private readonly DataClient _dataClient;
  private readonly ILogger<PlatformWatchHandler> _log;
  private readonly MessageClient _msgClient;
  private readonly NodeClient _nodeClient;

  public PlatformWatchHandler(ILogger<PlatformWatchHandler> log)
  {
    _log = log;

    _msgClient = WearableClass.GetMessageClient(Platform.AppContext);
    _dataClient = WearableClass.GetDataClient(Platform.AppContext);
    _capabilityClient = WearableClass.GetCapabilityClient(Platform.AppContext);
    _nodeClient = WearableClass.GetNodeClient(Platform.AppContext);
    _channelClient = WearableClass.GetChannelClient(Platform.AppContext);
  }

  public void OnCapabilityChanged(ICapabilityInfo capabilityInfo)
  {
    throw new NotImplementedException();
  }

  public void OnDataChanged(DataEventBuffer dataEvents)
  {
    throw new NotImplementedException();
  }

  public void OnMessageReceived(IMessageEvent messageEvent)
  {
    throw new NotImplementedException();
  }
}
*/
