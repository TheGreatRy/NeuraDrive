using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace NeuraDrive
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

            builder.Services.AddScoped(sp =>
                new HttpClient
                {
                    BaseAddress = new Uri("api.openf1.org/v1")
                }
            );

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
