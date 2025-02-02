using System;

namespace Learn.MauiWatchMobile.Models;

public delegate void WearableResponseEventDelegate(object sender, ResponseEventArgs e);

public class ResponseEventArgs : EventArgs
{
  public ResponseEventArgs(DateTime dttm, CommandType commandType, string? payload = null)
  {
    DateTime = dttm;
    CommandType = commandType;
    Payload = payload;
  }

  public DateTime DateTime { get; set; }

  public CommandType CommandType { get; set; } = CommandType.Unknown;

  public string? Payload { get; set; }
}
