using Android.Media.TV;
using MauiSqliteDB.DataAccess;
using Microsoft.Extensions.Logging;

namespace MauiSqliteDB
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

            builder.Services.AddDbContext<AppDbContext>();
            builder.Services.AddTransient<MainPage>();

            var dbcontext = new AppDbContext();
            dbcontext.Database.EnsureCreated();
            dbcontext.Dispose();

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
