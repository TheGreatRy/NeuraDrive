using Microsoft.Extensions.Logging;

namespace NeuraDrive
{
    //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
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

            return builder.Build();
        }
    }
}
