using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using LifeManagementApp.Services;
using System.Collections.ObjectModel;
using LifeManagementApp.Models;

namespace LifeManagementApp.ViewModels;

public partial class HomeViewModel : ObservableObject
{
    private readonly IWeatherService _weatherService;
    private readonly ITodoRepository _todoRepository;

    [ObservableProperty]
    private string temperatureText = "Haetaan säätietoja...";

    [ObservableProperty]
    private string windText = "";

    [ObservableProperty]
    private string kitesurfText = "";

    public ObservableCollection<TodoItem> TopTodos { get; set; } = new();

    public HomeViewModel(
        IWeatherService weatherService,
        ITodoRepository todoRepository)
    {
        _weatherService = weatherService;
        _todoRepository = todoRepository;

        LoadWeather();
        LoadTopTodos();
    }

    private async void LoadWeather()
    {
        try
        {
            var weather = await _weatherService.GetWeatherAsync();

            TemperatureText = $"Lämpötila: {weather.Temperature:F1} °C";

            WindText = $"Tuuli: {weather.WindSpeed:F1} m/s";

            KitesurfText = weather.IsKitesurfWeather
                ? "🏄 Kitesurf-keli!"
                : "Ei kitesurf-keliä";
        }
        catch
        {
            TemperatureText = "Säätietojen haku epäonnistui.";
            WindText = "";
            KitesurfText = "";
        }
    }

    private async void LoadTopTodos()
    {
        try
        {
            var todos = await _todoRepository.GetTopThreeAsync();

            TopTodos.Clear();

            foreach (var todo in todos)
            {
                TopTodos.Add(todo);
            }
        }
        catch
        {
            TemperatureText =
       "Säätietojen haku epäonnistui.";
        }
    }
}