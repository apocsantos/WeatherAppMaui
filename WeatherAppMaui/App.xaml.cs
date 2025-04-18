using WeatherAppMaui.Services;
using Microsoft.Maui.Controls; // For Application, NavigationPage

namespace WeatherAppMaui;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();
        var weatherService = new WeatherService();
        MainPage = new NavigationPage(new MainPage(weatherService));
    }
}