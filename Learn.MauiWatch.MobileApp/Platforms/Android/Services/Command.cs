using System;
using System.Text;
using System.Text.Json;
using Learn.MauiWatchMobile.Interfaces;

namespace Learn.MauiWatchMobile.Platforms.Android.Services;

public class Command : ICommand
{
  public object[]? BinaryPayload { get; set; }
  public string CommandType { get; set; } = string.Empty;
  public DateTime DateTime { get; set; }
  public double NumericPayload { get; set; }
  public string? StringPayload { get; set; }

  public byte[] ToBytes()
  {
    var json = JsonSerializer.Serialize(this);
    return Encoding.UTF8.GetBytes(json);
  }
}
