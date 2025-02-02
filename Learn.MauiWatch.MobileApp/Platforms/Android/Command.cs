using System;
using System.Text;
using System.Text.Json;
using Learn.MauiWatchMobile.Interfaces;
using Learn.MauiWatchMobile.Models;

namespace Learn.MauiWatchMobile.Platforms.Android;

public class Command : ICommand
{
  public CommandType CommandType { get; set; } = CommandType.Unknown;

  public DateTime DateTime { get; set; } = DateTime.Now;

  public string? Payload { get; set; }

  ////public object[]? PayloadBinary { get; set; }

  public byte[] ToBytes()
  {
    var json = JsonSerializer.Serialize(this);
    return Encoding.UTF8.GetBytes(json);
  }
}
