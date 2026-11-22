using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LifeManagementApp.ViewModels;

namespace LifeManagementApp.Views;

public partial class NotesPage : ContentPage
{
    public NotesPage(NotesViewModel viewModel)
    {
        InitializeComponent();

        BindingContext = viewModel;
    }
}