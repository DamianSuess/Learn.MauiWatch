namespace Learn.MauiWatchMobile.Interfaces;

public interface IWatchService
{
  ////public event WatchEvent OnWatchReceivedEvent;

  void Initialize();

  void Connect();

  void Disconnect();

  ////void ProcessResponse(IWatchPacket);
  void ProcessResponse();

  void SendMessage(string command, string payload);
}
