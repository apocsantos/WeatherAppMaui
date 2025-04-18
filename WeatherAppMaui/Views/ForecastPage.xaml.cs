// WeatherAppMaui/Views/ForecastPage.xaml.cs
using Microsoft.Maui.Controls;
using WeatherAppMaui.Services;

namespace WeatherAppMaui.Views;

public partial class ForecastPage : ContentPage
{
    private readonly WeatherService _weatherService;

    public ForecastPage(WeatherService weatherService)
    {
        InitializeComponent();
        _weatherService = weatherService;
    }
}