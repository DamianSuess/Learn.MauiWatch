using Learn.MauiWatchMobile.Models;

namespace Learn.MauiWatchMobile.Interfaces;

public interface IWearPacket
{
  public CommandType CommandType { get; set; }

  public ICommand CommandData { get; set; }

  public string ErrorMessage { get; set; }

  public StatusType StatusType { get; set; }
}
