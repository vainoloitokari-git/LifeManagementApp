using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    private int selectedPriority = 2;

    public List<string> Priorities { get; } =
        new()
        {
            "Erittäin tärkeä",
            "Ei kiireellinen",
            "Voi suorittaa myöhemmin"
        };

    [ObservableProperty]
    private string selectedPriorityText = "Ei kiireellinen";

    public TodoListViewModel(ITodoRepository repository)
    {
        _repository = repository;

        LoadTodos();
    }

    [RelayCommand]
    private async Task AddTodo()
    {
        if (string.IsNullOrWhiteSpace(NewTodoTitle))
            return;

        int priority = SelectedPriorityText switch
        {
            "Erittäin tärkeä" => 1,
            "Ei kiireellinen" => 2,
            "Voi suorittaa myöhemmin" => 3,
            _ => 2
        };

        var todo = new TodoItem
        {
            Title = NewTodoTitle,
            Priority = priority,
            IsDone = false,
            DueDate = DateTime.Now
        };

        await _repository.AddAsync(todo);

        NewTodoTitle = "";

        await LoadTodos();
    }

    private async Task LoadTodos()
    {
        Todos.Clear();

        var todos = await _repository.GetAllAsync();

        foreach (var todo in todos)
        {
            Todos.Add(todo);
        }
    }
}