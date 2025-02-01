using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Android.Gms.Common.Apis;
using Android.Gms.Extensions;
using Android.Gms.Wearable;
using Learn.MauiWatchMobile.Interfaces;
using Learn.MauiWatchMobile.Models;
using Microsoft.Extensions.Logging;
using Microsoft.Maui.ApplicationModel;

namespace Learn.MauiWatchMobile.Platforms.Android.Services;

// TODO: Move this to its own class since we can't use an interface with inheriting
public class WatchService :
  Java.Lang.Object,
  MessageClient.IOnMessageReceivedListener,
  DataClient.IOnDataChangedListener,
  CapabilityClient.IOnCapabilityChangedListener,
  IWatchService
{
  public const string CAPABILITY_SUESSLABS_WEAR = "suesslabs_watch_app";
  public const string MessagePath = "/message-payload";
  public const string FileTransfer = "/file-payload";

  private readonly CapabilityClient _capabilityClient;
  private readonly ChannelClient _channelClient;
  private readonly DataClient _dataClient;
  private readonly ILogger<WatchService> _log;
  private readonly MessageClient _msgClient;
  private readonly NodeClient _nodeClient;

  private INode? _primaryNode = null;
  private string _primaryDeviceId = string.Empty;

  public WatchService(ILogger<WatchService> logger, ILoggerFactory logFactory)
  {
    _log = logger;

    // Keep this just in case:
    ////var patformWatchLog = logFactory.CreateLogger<PlatformWatchHandler>();
    ////PlatformHandler = new PlatformWatchHandler(patformWatchLog);

    _msgClient = WearableClass.GetMessageClient(Platform.AppContext);
    _dataClient = WearableClass.GetDataClient(Platform.AppContext);
    _capabilityClient = WearableClass.GetCapabilityClient(Platform.AppContext);
    _nodeClient = WearableClass.GetNodeClient(Platform.AppContext);
    _channelClient = WearableClass.GetChannelClient(Platform.AppContext);

    Initialize();
  }

  public IPlatformWatchHandler PlatformHandler { get; private set; }

  public event WearableResponseEventDelegate ResponseReceived;

  /// <inheritdoc/>
  public async void Connect()
  {
    await _msgClient.AddListenerAsync(this);
    await _dataClient.AddListenerAsync(this);
    await _capabilityClient.AddListenerAsync(this, CAPABILITY_SUESSLABS_WEAR);

    if (await VerifyWearableAsync() && _primaryNode is not null)
    {
      _log.LogInformation(
        "Wearable found and paired to {0} ({1}).",
        _primaryNode.DisplayName,
        _primaryNode.Id);
    }
  }

  /// <inheritdoc/>
  public async void Disconnect()
  {
    await _msgClient.RemoveListenerAsync(this);
    await _dataClient.RemoveListenerAsync(this);
    await _capabilityClient.RemoveListenerAsync(this, CAPABILITY_SUESSLABS_WEAR);
  }

  public void Initialize()
  {
    Connect();

    // MessageReceived += OnMessageReceived(IWatchPacket packet)
  }

  public void OnCapabilityChanged(ICapabilityInfo capabilityInfo)
  {
    throw new System.NotImplementedException();
  }

  public void OnDataChanged(DataEventBuffer dataEvents)
  {
    throw new System.NotImplementedException();
  }

  public void OnMessageReceived(IMessageEvent messageEvent)
  {
    if (messageEvent.SourceNodeId != _primaryDeviceId)
    {
      _log.LogInformation("Message from unknown wearable device, '{device}'", messageEvent.SourceNodeId);
      return;
    }

    switch (messageEvent.Path)
    {
      case MessagePath:
        break;
    }
  }

  public void ProcessResponse(IWearPacket packet)
  {
    switch (packet.CommandType)
    {
      case CommandType.ContextUpdate:
      case CommandType.UserInfo:
      case CommandType.Message:
        break;
      case CommandType.File:
        break;
    }
  }

  public async void SendMessageAsync(
    string cmdType,
    string stringPayload = "",
    double numericPayload = double.NaN,
    IEnumerable<object>? bytePayload = null)
  {
    if (string.IsNullOrEmpty(_primaryDeviceId))
      await GetDeviceIdAsync();

    var cmd = new Command
    {
      CommandType = cmdType,
      StringPayload = stringPayload,
      NumericPayload = numericPayload,
      BinaryPayload = bytePayload?.ToArray() ?? [],
    };

    try
    {
      _log.LogInformation("Sending '{cmd}' to node, {node}", cmdType, _primaryDeviceId);

      await WearableClass.GetMessageClient(Platform.AppContext).SendMessage(
        _primaryDeviceId,
        MessagePath,
        cmd.ToBytes(),
        new MessageOptions(MessageOptions.MessagePriorityHigh));

    }
    catch
    {
    }
  }

  private async Task GetDeviceIdAsync()
  {
    throw new NotImplementedException();
  }

  private async Task<bool> VerifyWearableAsync()
  {
    var capability = await _capabilityClient.GetCapabilityAsync(CAPABILITY_SUESSLABS_WEAR, CapabilityClient.FilterAll);
    if (capability is null)
      return false;

    if (capability.Nodes.Count == 0)
    {
      _log.LogInformation("Wearable couldn't find mobile app.");
      return false;
    }
    else
    {
      var firstNode = capability.Nodes.First();

      _log.LogInformation(
        "Wearable '{name}' found {count} devices.",
        firstNode.DisplayName,
        capability.Nodes.Count);

      _primaryNode = firstNode;
      _primaryDeviceId = firstNode.Id;
      return true;
    }
  }
}
