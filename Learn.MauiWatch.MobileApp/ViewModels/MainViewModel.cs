using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Microsoft.Maui.Controls;

namespace Learn.MauiWatchMobile.ViewModels;

public class MainViewModel : INotifyPropertyChanged
{
  private string _watchMessage;

  public event PropertyChangedEventHandler? PropertyChanged;

  public MainViewModel()
  {
    CmdSendMessage = new Command(
      execute: () =>
      {
        //Entry = "0";
        //RefreshCanExecutes();
      });
  }

  public string WatchMessage
  {
    get => _watchMessage;
    set => SetProperty(ref _watchMessage, value);
  }

  public ICommand CmdSendMessage { get; private set; }

  protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
  {
    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
  }

  private bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string propertyName = null)
  {
    if (Object.Equals(storage, value))
      return false;

    storage = value;
    OnPropertyChanged(propertyName);
    return true;
  }
}
