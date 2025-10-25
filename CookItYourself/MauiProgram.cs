using CookItYourself.Data;
using Microsoft.Extensions.Logging;

namespace CookItYourself
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
            // Define target DB path in local app folder
            string dbName = "RecipeDB.db";
            string targetPath = Path.Combine(FileSystem.AppDataDirectory, dbName);

            // Copy prebuilt database if not already there
            if (!File.Exists(targetPath))
            {
                using var stream = FileSystem.OpenAppPackageFileAsync(dbName).Result;
                using var newFile = File.Create(targetPath);
                stream.CopyTo(newFile);
                Console.WriteLine($"Copied DB Path: {targetPath}");
            }
            Console.WriteLine($"Database Path: {targetPath}");
            builder.Services.AddSingleton<DatabaseService>(s => new DatabaseService(targetPath));
            string desktop = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            string logPath = Path.Combine(desktop, "logDBPath.txt");
            File.WriteAllText(logPath, targetPath);
            return builder.Build();
        }
    }
}
