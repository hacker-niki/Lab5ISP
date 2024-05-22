using System.Reflection;
using CommunityToolkit.Maui;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Senko_253505.Application;
using Senko_253505.Persistence;
using Senko_253505.Persistence.Data;

namespace Senko_253505.UI;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        // string settingsStream = "Senko253505.UI.appsettings.json";

        var builder = MauiApp.CreateBuilder();
        builder.UseMauiApp<App>().ConfigureFonts(fonts =>
        {
            fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
            fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
        }).UseMauiCommunityToolkit();

        // var a = Assembly.GetExecutingAssembly();
        // using var stream = a.GetManifestResourceStream(settingsStream);
        // builder.Configuration.AddJsonStream(stream);

        // var connStr = builder.Configuration
        //     .GetConnectionString("SqliteConnection");

        var connStr = " Data Source = {0}sqlite.db";
        string dataDirectory = FileSystem.Current.AppDataDirectory + "/";
        connStr = String.Format(connStr, dataDirectory);
        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseSqlite(connStr)
            .Options;

        builder.Services.AddApplication().AddPersistence(options).RegisterPages().RegisterViewModels();


#if DEBUG
        builder.Logging.AddDebug();
#endif
        DbInitializer.Initialize(builder.Services.BuildServiceProvider())
            .Wait();
        return builder.Build();
    }
}