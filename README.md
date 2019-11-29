# RoundedFrame

[![NuGet Package](https://img.shields.io/nuget/v/Plugin.RoundedFrame.svg)](https://www.nuget.org/packages/Plugin.RoundedFrame/1.0.2)

| Platform | Version | Build |
| ------- | ------- | ------- |
|Xamarin.Android| API 26+ | <img src="https://img.shields.io/static/v1?label=build&message=passing&color=green"/> |
|Windows 10 UWP | 10+ | <img src="https://img.shields.io/static/v1?label=build&message=passing&color=green"/> |
|Xamarin.iOS | iOS 10+ | <img src="https://img.shields.io/static/v1?label=build&message=passing&color=green"/>|

## NuGet Installation

Install [Plugin.RoundedFrame](https://www.nuget.org/packages/Plugin.RoundedFrame/1.0.1) from NuGet.

**Important:** You will need to add the NuGet package to **both** your *.NET Standard library project* and your *platform-dependent app project*.

**XAML**

Add reference
```xml 
<ContentPage
	xmlns:control="clr-namespace:Plugin.RoundedFrame;assembly=Plugin.RoundedFrame"/>
```
Usage
```xml
<control:CrossRoundedFrame
	CornerRadius="10,20,30,40"
	HeightRequest="200"
	WidthRequest="200"/>
```
## Please Contribute!

This is an open source project that welcomes contributions/suggestions/bug reports from those who use it. If you have any ideas on how to improve the library, please [post an issue here on GitHub](https://github.com/charlynedsson/RoundedFrame/issues).

## Xamarin Templates
This plugin was packed with James Motemongo's [Xamarin Templates](https://github.com/jamesmontemagno/Xamarin-Templates).
