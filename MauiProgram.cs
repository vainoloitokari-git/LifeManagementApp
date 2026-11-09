using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using LifeManagementApp.Data;
using LifeManagementApp.Services;
using Microsoft.Extensions.DependencyInjection;

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

            builder.Services.AddDbContext<AppDbContext>(options =>
            {
                var dbPath = Path.Combine(
                    FileSystem.AppDataDirectory,
                    "todo.db");

                options.UseSqlite($"Data Source={dbPath}");
            });

            builder.Services.AddScoped<ITodoRepository, TodoRepository>();

            builder.Services.AddHttpClient<IWeatherService,
                                          OpenMeteoWeatherService>();

            return builder.Build();
        }
    }
}