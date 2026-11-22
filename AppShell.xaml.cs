using LifeManagementApp.Views;
using Microsoft.Extensions.DependencyInjection;

namespace LifeManagementApp
{
    public partial class AppShell : Shell
    {
        public AppShell(IServiceProvider services)
        {
            InitializeComponent();

            HomeShellContent.ContentTemplate = new DataTemplate(
                () => services.GetRequiredService<HomePage>());
            TodoShellContent.ContentTemplate = new DataTemplate(
                () => services.GetRequiredService<TodoListPage>());
            NotesShellContent.ContentTemplate = new DataTemplate(
                () => services.GetRequiredService<NotesPage>());
        }
    }
}
