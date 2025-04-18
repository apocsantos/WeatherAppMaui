// WeatherAppMaui/Views/HistoryPage.xaml.cs
using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Maui.ApplicationModel;
using Microsoft.Maui.Controls;
using WeatherAppMaui.Models;
using WeatherAppMaui.Services;

namespace WeatherAppMaui.Views;

public partial class HistoryPage : ContentPage
{
    private readonly WeatherService _weatherService;

    public HistoryPage(WeatherService weatherService)
    {
        InitializeComponent();
        _weatherService = weatherService;
        Task.Run(LoadHistoryAsync);
    }

    private async Task LoadHistoryAsync()
    {
        try
        {
            var response = await _weatherService.FetchWeatherHistoryAsync();
            if (response?.Status == "success" && response.Data != null)
            {
                var items = response.Data.Select(d => new
                {
                    Timestamp = d.UpdateTimestamp ?? "N/A",
                    DisplayText = $"Temp: {(double.TryParse(d.Temperature, out double temp) ? temp : 0)}°C, " +
                                  $"Humidity: {(double.TryParse(d.Humidity, out double humid) ? humid : 0)}%, " +
                                  $"Wind: {(double.TryParse(d.WindSpeed, out double wind) ? wind : 0)} m/s"
                });
                MainThread.BeginInvokeOnMainThread(() =>
                {
                    HistoryList.ItemsSource = items;
                });
            }
            else
            {
                await DisplayAlert("Error", "Failed to load history", "OK");
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", ex.Message, "OK");
        }
    }
}