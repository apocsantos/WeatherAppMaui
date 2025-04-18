// WeatherAppMaui/MainPage.xaml.cs
using System;
using System.Threading.Tasks;
using Microsoft.Maui.ApplicationModel;
using Microsoft.Maui.Controls;
using WeatherAppMaui.Services;
using WeatherAppMaui.Views;

namespace WeatherAppMaui;

public partial class MainPage : ContentPage
{
    private readonly WeatherService _weatherService;
    private readonly System.Timers.Timer _timer;

    public MainPage(WeatherService weatherService)
    {
        InitializeComponent();
        _weatherService = weatherService;
        _timer = new System.Timers.Timer(30000);
        _timer.Elapsed += async (s, e) => await LoadWeatherAsync();
        _timer.Start();
        Task.Run(LoadWeatherAsync);
    }

    private async Task LoadWeatherAsync()
    {
        try
        {
            Console.WriteLine("Fetching weather data...");
            var data = await _weatherService.FetchLatestWeatherAsync();
            Console.WriteLine($"Data received: {System.Text.Json.JsonSerializer.Serialize(data)}");
            if (data != null)
            {
                MainThread.BeginInvokeOnMainThread(() =>
                {
                    TempLabel.Text = $"Temperature: {(double.TryParse(data.Temperature, out double temp) ? temp : 0)}°C";
                    HumidityLabel.Text = $"Humidity: {(double.TryParse(data.Humidity, out double humid) ? humid : 0)}%";
                    WindLabel.Text = $"Wind Speed: {(double.TryParse(data.WindSpeed, out double wind) ? wind : 0)} m/s";
                    TimestampLabel.Text = $"Timestamp: {data.UpdateTimestamp ?? "N/A"}";
                    ConditionLabel.Text = "Condition: N/A";
                    ErrorLabel.IsVisible = false;
                    LoadingIndicator.IsRunning = false;
                });
            }
            else
            {
                MainThread.BeginInvokeOnMainThread(() =>
                {
                    ErrorLabel.Text = "No data available";
                    ErrorLabel.IsVisible = true;
                    LoadingIndicator.IsRunning = false;
                });
            }
        }
        catch (Exception ex)
        {
            MainThread.BeginInvokeOnMainThread(() =>
            {
                ErrorLabel.Text = $"Error: {ex.Message}";
                ErrorLabel.IsVisible = true;
                LoadingIndicator.IsRunning = false;
            });
            Console.WriteLine($"Fetch error: {ex}");
        }
    }

    private async void OnHistoryClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new HistoryPage(_weatherService));
    }

    private async void OnForecastClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new ForecastPage(_weatherService));
    }
}