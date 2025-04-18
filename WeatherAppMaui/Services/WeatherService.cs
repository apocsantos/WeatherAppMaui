// WeatherAppMaui/Services/WeatherService.cs
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using WeatherAppMaui.Models;

namespace WeatherAppMaui.Services;

public class WeatherService
{
    private readonly HttpClient _httpClient;
    private const string BaseUrl = "https://meteo.aeaveromar.pt/api/"; // Replace with your actual URL

    public WeatherService()
    {
        _httpClient = new HttpClient();
    }

    public async Task<WeatherData?> FetchLatestWeatherAsync()
    {
        return await _httpClient.GetFromJsonAsync<WeatherData>($"{BaseUrl}fetch.php");
    }

    public async Task<HistoryResponse?> FetchWeatherHistoryAsync()
    {
        return await _httpClient.GetFromJsonAsync<HistoryResponse>($"{BaseUrl}history.php");
    }
}