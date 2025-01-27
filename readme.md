# Learn - Watch WearMaui with .NET MAUI

This repository provides an example on how to crete a Watch app with .NET MAUI and link it to your mobile app.

**Author:** [Damian Suess](https://www.linkedin.com/in/damiansuess/)<br/>
**Website:** [SuessLabs.com](https://suesslabs.com)<br/>
_Submitted with ❤ by Xeno Innovations, Inc. and Suess Labs._

## Project Configuration

The projects disable `ImplicitUsings` so that you can cearly see which libraries and namespaces need to be included for each class.

### Tech Stack

* .NET MAUI v8
* Android Wear API 34

## Recreate Wear App

### Put Watch into Developer Mode

Place your watch into ***Developer***  mode by performing the following:

1. Go to **System** -> **About Watch** -> **Software Information**
2. Tap the _"Software version"_ section 7 times.

### Permissions - AndroidManifest.xml

```xml
  <uses-feature android:name="android.hardware.type.watch" />
  <uses-permission android:name="android.permission.ACCESS_NETWORK_STATE" />
  <uses-permission android:name="android.permission.INTERNET" />
```

## Recreate Mobile App

### Permissions

* `<uses-permission android:name="android.permission.ACCESS_NETWORK_STATE" />`
* `<uses-permission android:name="android.permission.INTERNET" />`

## References

* [MAUI Wear OS/Watch OS Support](https://github.com/dotnet/maui/discussions/1144)
* [Showcase-1](https://www.saboit.de/blog/net-maui-android-watch-application-showcase-part-1) [Showcase-2](https://www.saboit.de/blog/net-maui-android-watch-application-showcase-part-2)
* Dimmer-MAUI [App](https://github.com/YBTopaz8/Dimmer-MAUI) - [Wear](https://github.com/YBTopaz8/DimmerWatchWearMaui)
