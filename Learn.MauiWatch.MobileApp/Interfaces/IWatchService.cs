using Learn.MauiWatchMobile.Models;

namespace Learn.MauiWatchMobile.Interfaces;

public interface IWatchService
{
  ////public event WatchEvent OnWatchReceivedEvent;
  public event WearableResponseEventDelegate ResponseReceived;

  IPlatformWatchHandler? PlatformHandler { get; }

  void Initialize();

  void Connect();

  void Disconnect();

  ////void ProcessResponse(IWatchPacket);
  void ProcessResponse(IWearPacket packet);

  /// <summary>Send message payload.</summary>
  /// <remarks>Overload method to simplify parameters.</remarks>
  /// <param name="commandType">Payload command type.</param>
  /// <param name="payload">Payload data.</param>
  ////void SendMessageAsync(CommandType commandType, IEnumerable<object>? payload = null);
  void SendMessageAsync(CommandType commandType, string payload = "");
}
