﻿using Android.App;
using Android.Content.PM;
using Microsoft.Maui;
using Microsoft.Maui.Controls.Platform; // For MauiAppCompatActivity

namespace WeatherAppMaui;

[Activity(Theme = "@style/Maui.SplashTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
public class MainActivity : MauiAppCompatActivity
{
}