using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using LifeManagementApp.Data;
using LifeManagementApp.Services;
using Microsoft.Extensions.DependencyInjection;
using LifeManagementApp.ViewModels;
using LifeManagementApp.Views;
using LifeManagementApp.Models;

namespace LifeManagementApp
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();

            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
            builder.Logging.AddDebug();
#endif

            // SQLite / EF Core

            builder.Services.AddDbContext<AppDbContext>(options =>
            {
                string dbPath = Path.Combine(
                    FileSystem.AppDataDirectory,
                    "todo.db");

                options.UseSqlite(
                    $"Data Source={dbPath}");
            });

            // Repositories

            builder.Services.AddScoped<ITodoRepository, TodoRepository>();

            // Services

            builder.Services.AddHttpClient<IWeatherService,
                                           OpenMeteoWeatherService>();

            // ViewModels

            builder.Services.AddTransient<HomeViewModel>();
            builder.Services.AddTransient<TodoListViewModel>();

            // Pages

            builder.Services.AddTransient<HomePage>();
            builder.Services.AddTransient<TodoListPage>();

            return builder.Build();
        }
    }
}