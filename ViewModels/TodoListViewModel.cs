using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using LifeManagementApp.Models;
using LifeManagementApp.Services;

namespace LifeManagementApp.ViewModels;

public partial class TodoListViewModel : ObservableObject
{
    private readonly ITodoRepository _repository;

    public ObservableCollection<TodoItem> Todos { get; set; } = new();

    [ObservableProperty]
    private string newTodoTitle = "";

    [ObservableProperty]
    private string selectedPriorityText = "Ei kiireellinen";

    [ObservableProperty]
    private DateTime selectedDueDate = DateTime.Today;

    [ObservableProperty]
    private string selectedSortOption =
        "Prioriteetti (korkea → matala)";

    public List<string> Priorities { get; } =
        new()
        {
            "Erittäin tärkeä",
            "Hieman tärkeä",
            "Ei kiireellinen",
            "Voi suorittaa myöhemmin"
        };

    public List<string> SortOptions { get; } =
        new()
        {
            "Prioriteetti (korkea → matala)",
            "Prioriteetti (matala → korkea)",
            "Päivämäärä (uusin ensin)",
            "Päivämäärä (vanhin ensin)"
        };

    public TodoListViewModel(ITodoRepository repository)
    {
        _repository = repository;

        _ = LoadTodos();
    }

    [RelayCommand]
    private async Task AddTodo()
    {
        if (string.IsNullOrWhiteSpace(NewTodoTitle))
            return;

        int priority = SelectedPriorityText switch
        {
            "Erittäin tärkeä" => 1,
            "Hieman tärkeä" => 2,
            "Ei kiireellinen" => 3,
            "Voi suorittaa myöhemmin" => 4,
            _ => 3
        };

        var todo = new TodoItem
        {
            Title = NewTodoTitle,
            Priority = priority,
            DueDate = SelectedDueDate,
            IsDone = false
        };

        await _repository.AddAsync(todo);

        NewTodoTitle = "";
        SelectedDueDate = DateTime.Today;
        SelectedPriorityText = "Ei kiireellinen";

        await LoadTodos();
    }

    private async Task LoadTodos()
    {
        Todos.Clear();

        var todos = await _repository.GetAllAsync();

        todos = SelectedSortOption switch
        {
            "Prioriteetti (korkea → matala)"
                => todos.OrderBy(t => t.Priority).ToList(),

            "Prioriteetti (matala → korkea)"
                => todos.OrderByDescending(t => t.Priority).ToList(),

            "Päivämäärä (uusin ensin)"
                => todos.OrderByDescending(t => t.DueDate).ToList(),

            "Päivämäärä (vanhin ensin)"
                => todos.OrderBy(t => t.DueDate).ToList(),

            _ => todos
        };

        foreach (var todo in todos)
        {
            Todos.Add(todo);
        }
    }

    partial void OnSelectedSortOptionChanged(string value)
    {
        _ = LoadTodos();
    }
}