using LifeManagementApp.ViewModels;

namespace LifeManagementApp.Views;

public partial class TodoListPage : ContentPage
{
    public TodoListPage()
    {
        InitializeComponent();

        BindingContext = new TodoListViewModel();
    }
}