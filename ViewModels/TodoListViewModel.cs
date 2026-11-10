using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using LifeManagementApp.Models;

namespace LifeManagementApp.ViewModels;

public partial class TodoListViewModel : ObservableObject
{
    public ObservableCollection<TodoItem> Todos { get; set; }

    public TodoListViewModel()
    {
        Todos = new ObservableCollection<TodoItem>()
        {
            new TodoItem
            {
                Title = "Lämmitä sauna",
                Priority = 1
            },

            new TodoItem
            {
                Title = "Tilaa ruokaa",
                Priority = 2
            },

            new TodoItem
            {
                Title = "Avaa pari kaljaa",
                Priority = 1
            },

            new TodoItem
            {
                Title = "Tiskaa tiskit",
                Priority = 3
            }
        };
    }
}

