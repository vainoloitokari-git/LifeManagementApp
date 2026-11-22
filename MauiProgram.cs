using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using LifeManagementApp.Data;
using LifeManagementApp.Services;
using LifeManagementApp.ViewModels;
using LifeManagementApp.Views;

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

            // SQLite

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
            builder.Services.AddScoped<INoteRepository, NoteRepository>();

            // Services

            // Services

            builder.Services.AddHttpClient<IWeatherService,
                                           OpenMeteoWeatherService>();

            // ViewModels

            builder.Services.AddTransient<HomeViewModel>();
            builder.Services.AddTransient<TodoListViewModel>();
            builder.Services.AddTransient<NotesViewModel>();

            // Pages

            builder.Services.AddTransient<HomePage>();
            builder.Services.AddTransient<TodoListPage>();
            builder.Services.AddTransient<NotesPage>();
            builder.Services.AddSingleton<AppShell>();

            var app = builder.Build();

            using (var scope = app.Services.CreateScope())
            {
                var db = scope.ServiceProvider
                    .GetRequiredService<AppDbContext>();

                db.Database.EnsureCreated();
            }

            return app;
        }
    }
}