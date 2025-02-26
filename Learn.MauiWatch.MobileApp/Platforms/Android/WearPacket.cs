using Learn.MauiWatchMobile.Interfaces;
using Learn.MauiWatchMobile.Models;

namespace Learn.MauiWatchMobile.Platforms.Android;

public class WearPacket
{
  /// <remarks>Redundant.</remarks>
  public ICommand Command { get; set; }

  public CommandType CommandType { get; set; }

  public string? ErrorMessage { get; set; }

  public StatusType StatusType { get; set; }
}
