// WeatherAppMaui/Models/WeatherData.cs
using System.Collections.Generic;

namespace WeatherAppMaui.Models;

public class WeatherData
{
    public string? Id { get; set; }
    public string? StationId { get; set; }
    public string? Temperature { get; set; }
    public string? Humidity { get; set; }
    public string? Pressure { get; set; }
    public string? WindSpeed { get; set; }
    public string? WindGust { get; set; }
    public string? DewPoint { get; set; }
    public string? Rainfall { get; set; }
    public string? DateUtc { get; set; }
    public string? InsertTimestamp { get; set; }
    public string? UpdateTimestamp { get; set; } // Used as Timestamp
    public string? Message { get; set; } // Optional, for condition
}

public class HistoryResponse
{
    public string? Status { get; set; }
    public List<WeatherData> Data { get; set; } = new List<WeatherData>();
}