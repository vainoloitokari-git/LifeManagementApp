using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using LifeManagementApp.Services;

namespace LifeManagementApp.ViewModels;

public partial class NotesViewModel : ObservableObject
{
    private readonly INoteRepository _repository;

    [ObservableProperty]
    private string notesText = "";

    public NotesViewModel(INoteRepository repository)
    {
        _repository = repository;

        _ = LoadNote();
    }

    private async Task LoadNote()
    {
        var note = await _repository.GetNoteAsync();

        if (note != null)
        {
            NotesText = note.Content;
        }
    }

    [RelayCommand]
    private async Task SaveNote()
    {
        await _repository.SaveNoteAsync(NotesText);
    }
}
