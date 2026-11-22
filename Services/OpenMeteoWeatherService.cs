using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using LifeManagementApp.Models;

namespace LifeManagementApp.Services;

public class OpenMeteoWeatherService : IWeatherService
{
    private readonly HttpClient _httpClient;

    public OpenMeteoWeatherService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<WeatherInfo> GetWeatherAsync()
    {
        string url =
            "https://api.open-meteo.com/v1/forecast?latitude=63.10&longitude=21.62&current=temperature_2m,wind_speed_10m&wind_speed_unit=ms";

        string json = await _httpClient.GetStringAsync(url);

        using JsonDocument document = JsonDocument.Parse(json);

        var current = document.RootElement.GetProperty("current");

        return new WeatherInfo
        {
            Temperature =
                current.GetProperty("temperature_2m").GetDouble(),

            WindSpeed =
                current.GetProperty("wind_speed_10m").GetDouble()
        };
    }
}