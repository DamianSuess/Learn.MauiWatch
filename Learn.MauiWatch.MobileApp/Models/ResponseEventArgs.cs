using System;

namespace Learn.MauiWatchMobile.Models;

public delegate void WearableResponseEventDelegate(object sender, ResponseEventArgs e);

public class ResponseEventArgs : EventArgs
{
  public ResponseEventArgs(DateTime dttm, string commandType, string? stringPayload = null, double? numericPayload = null)
  {
    DateTime = dttm;
    CommandType = commandType;
    StringPayload = stringPayload;
    NumericPayload = numericPayload;
  }

  public DateTime DateTime { get; set; }

  public string CommandType { get; set; } = string.Empty;

  public string? StringPayload { get; set; }

  public double? NumericPayload { get; set; }
}
