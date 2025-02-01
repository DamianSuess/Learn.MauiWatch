﻿# Learn - Watch WearMaui with .NET MAUI

This repository provides an example on how to crete a Watch app with .NET MAUI and link it to your mobile app.

**Author:** [Damian Suess](https://www.linkedin.com/in/damiansuess/)<br/>
**Website:** [SuessLabs.com](https://suesslabs.com)<br/>
_Submitted with ❤ by Xeno Innovations, Inc. and Suess Labs._

![screen-shot](docs/Wear-Emu.png)

## Project Configuration

The projects disable `ImplicitUsings` so that you can clearly see which libraries and namespaces need to be included for each class.

### Tech Stack

* .NET MAUI v8
* Android Wear API 34

### The Projects

1. Learn.MauiWatch.MobileApp - All-in-one Mobile and Wear apps
   * Status: In-progress
   * Features: Watch to App communication
   * Packages:
     * `Xamarin.GooglePlayServices.Wearable`
2. Learn.MauiWatch.Wearable - Xamarin.Android based Wear app
   * Status: Done
   * Features: UI Only
3. Learn.MauiWatch.WearMaui - .NET MAUI UI exclusive UI
   * Status: Done - UI Only
   * Features: UI Only

### Put Watch into Developer Mode

Place your watch into ***Developer***  mode by performing the following:

1. Go to **System** -> **About Watch** -> **Software Information**
2. Tap the _"Software version"_ section 7 times.

## Recreate Wear MAUI App

For the MAUI Android Wear app, you don't have to do much to get it up and running. Notice, we didn't event need to add to the `AndroidManifest.xml` file, `<uses-feature android:name="android.hardware.type.watch" />`.

To perform communications you can choose between WiFi or Bluetooth. The more common being, Bluetooth for communication between the app and wearable.

## Recreate Mobile App (All-In-One)

### Requirements

NuGet Packages:

* `Xamarin.GooglePlayServices.Wearable`

AndroidManifest.xml Permissions:

* `<uses-permission android:name="android.permission.ACCESS_NETWORK_STATE" />`
* `<uses-permission android:name="android.permission.INTERNET" />`

## Learn MAUI Watch MobileApp (All-in-One)

### Got Ya's

1. This app requires the package, `Xamarin.GooglePlayServices.Wearable` v118.x. The first iteration will use this version.
   * As of version v119.x, `MessageOptions` class is no longer available; _no documentation either_.
     * `com/google/android/gms/wearable/MessageClient`
   * The (lack of) documentation suggests [Wearable.WearableOptions](https://developers.google.com/android/reference/com/google/android/gms/wearable/Wearable.WearableOptions)
   * See also from, developers.google.com:
     * [Wearable API](https://developers.google.com/android/reference/com/google/android/gms/wearable/Wearable)
     * [MessageClient API](https://developers.google.com/android/reference/com/google/android/gms/wearable/MessageClient)

## References

Official Guides:

* [MAUI Wear OS/Watch OS Support](https://github.com/dotnet/maui/discussions/1144)
* [Watch Face](https://github.com/MicrosoftDocs/xamarin-docs/blob/live/docs/android/wear/platform/creating-a-watchface.md)

Around the Internet:

* [Showcase-1](https://www.saboit.de/blog/net-maui-android-watch-application-showcase-part-1) [Showcase-2](https://www.saboit.de/blog/net-maui-android-watch-application-showcase-part-2)
* Dimmer-MAUI [App](https://github.com/YBTopaz8/Dimmer-MAUI) - [Wear](https://github.com/YBTopaz8/DimmerWatchWearMaui)
  * [Parse-LiveQueries](https://github.com/YBTopaz8/Parse-LiveQueries-DOTNET) comms.
* [MAUI with Watch Apps](https://github.com/vouksh/MauiWithWatchApps)

### Issues Encountered

#### Type androidx.collection.ArrayMapKt is defined multiple times:

##### Error Message

```
Type androidx.collection.ArrayMapKt is defined multiple times:
 C:\Users\USERNAME\.nuget\packages\xamarin.androidx.collection.jvm\1.4.0.4\buildTransitive\net8.0-android34.0\..\..\jar\androidx.collection.collection-jvm.jar:androidx/collection/ArrayMapKt.class,
 C:\Users\USERNAME\.nuget\packages\xamarin.androidx.collection.ktx\1.2.0.9\buildTransitive\net6.0-android31.0\..\..\jar\androidx.collection.collection-ktx.jar:androidx/collection/ArrayMapKt.class
```

Note, the following versions for `xamarin.androidx.collection` are in conflict. We need force Kotlin (`ktx`) to use the same version as JVM.
* JVM: 1.4.0.4
* KTX: 1.2.0.9

##### The Fix

```xml
    <PackageReference Include="Xamarin.AndroidX.Collection.Ktx">
      <Version>1.4.0.4</Version>
    </PackageReference>
```

##### Similar Issues

* [AndroidX.Collection.ArrayMapKt is defined multiple times (GitHub - MAUI: #18665)](https://github.com/dotnet/maui/issues/18665)
* [Java linking conflict when adding Xamarin.AndroidX... (GitHub - MAUI: 26963)](https://github.com/dotnet/maui/issues/26963)
* [Workaround (GitHub - Android-Libraries: #764)](https://github.com/dotnet/android-libraries/issues/764)

```xml
  <ItemGroup Condition="'$(TargetFramework)' == 'net8.0-android34.0'">
    <PackageReference Include="Xamarin.GooglePlayServices.Location" Version="121.0.1.4" />
    <PackageReference Include="Xamarin.AndroidX.Activity" Version="1.8.1.1" />
    <PackageReference Include="Xamarin.AndroidX.Activity.Ktx" Version="1.8.1.1" />
    <PackageReference Include="Xamarin.AndroidX.Fragment.Ktx" Version="1.6.2.1" />
  </ItemGroup>
```
