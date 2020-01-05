# RoundedFrame

[![Build Status](https://dev.azure.com/charlynedsson/charlynedsson/_apis/build/status/charlynedsson.RoundedFrame?branchName=master)](https://dev.azure.com/charlynedsson/charlynedsson/_build/latest?definitionId=7&branchName=master)
[![NuGet Package](https://img.shields.io/nuget/v/Plugin.RoundedFrame.svg)](https://www.nuget.org/packages/Plugin.RoundedFrame)

| Platform | Version | CornerRadius | GradientColor |
| ------- | ------- | ------- | ------- |
|Xamarin.Android| API 26+ | Supported | Supported |
|Windows 10 UWP | 10+ | Supported | Supported |
|Xamarin.iOS | iOS 10+ | Supported | Not supported |

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
	StartColor="Red"
	EndColor="Yellow"
	GradientDirection="ToBottom"
	HorizontalOptions="Center"
	VerticalOptions="CenterAndExpand"		   
	HeightRequest="200"
	WidthRequest="200"/>
```
## Please Contribute!

This is an open source project that welcomes contributions/suggestions/bug reports from those who use it. If you have any ideas on how to improve the library, please [post an issue here on GitHub](https://github.com/charlynedsson/RoundedFrame/issues).

## Xamarin Templates
This plugin was packed with James Motemango's [Xamarin Templates](https://github.com/jamesmontemagno/Xamarin-Templates).
