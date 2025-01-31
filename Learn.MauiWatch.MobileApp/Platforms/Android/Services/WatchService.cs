using Android.Gms.Wearable;
using Learn.MauiWatchMobile.Interfaces;
using Microsoft.Extensions.Logging;
using Microsoft.Maui.ApplicationModel;

namespace Learn.MauiWatchMobile.Platforms.Android.Services;

// TODO: Move this to its own class since we can't use an interface with inheriting
public class WatchService : IWatchService ////, Java.Lang.Object
{
  private readonly CapabilityClient _capabilityClient;
  private readonly ChannelClient _channelClient;
  private readonly DataClient _dataClient;
  private readonly ILogger<WatchService> _log;
  private readonly MessageClient _msgClient;
  private readonly NodeClient _nodeClient;

  public WatchService(ILogger<WatchService> logger)
  {
    _log = logger;

    _msgClient = WearableClass.GetMessageClient(Platform.AppContext);
    _dataClient = WearableClass.GetDataClient(Platform.AppContext);
    _capabilityClient = WearableClass.GetCapabilityClient(Platform.AppContext);
    _nodeClient = WearableClass.GetNodeClient(Platform.AppContext);
    _channelClient = WearableClass.GetChannelClient(Platform.AppContext);

    Initialize();
  }

  public async void Connect()
  {
    await _msgClient.AddListenerAsync(this);
  }

  public void Disconnect()
  {
  }

  public void Initialize()
  {
    Connect();
    // MessageReceived += OnMessageReceived(IWatchPacket packet)
  }

  public void ProcessResponse()
  {
  }

  public void SendMessage(string command, string payload)
  {
  }

  public void OnMessageReceived(IMessageEvent messageEvent)
  {
  }
}
