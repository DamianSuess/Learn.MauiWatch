using System;
using Learn.MauiWatchMobile.Models;

namespace Learn.MauiWatchMobile.Interfaces;

public interface ICommand
{
  CommandType CommandType { get; set; }

  DateTime DateTime { get; set; }

  string? Payload { get; set; }
}
