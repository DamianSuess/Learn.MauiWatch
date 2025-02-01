using System.Collections.Generic;
using Learn.MauiWatchMobile.Models;

namespace Learn.MauiWatchMobile.Interfaces;

public interface IWatchService
{
  ////public event WatchEvent OnWatchReceivedEvent;
  public event WearableResponseEventDelegate ResponseReceived;

  IPlatformWatchHandler PlatformHandler { get; }

  void Initialize();

  void Connect();

  void Disconnect();

  ////void ProcessResponse(IWatchPacket);
  void ProcessResponse(IWearPacket packet);

  /// <summary>Send message payload.</summary>
  /// <remarks>Overload method to simplify parameters.</remarks>
  /// <param name="command">Pay.oad command.</param>
  /// <param name="dataString">Payload data.</param>
  /// <param name="dataNumber">Payload data.</param>
  /// <param name="dataBytes">Payload data.</param>
  void SendMessageAsync(string command,
    string dataString = "",
    double dataNumber = double.NaN,
    IEnumerable<object>? dataBytes = null);
}
