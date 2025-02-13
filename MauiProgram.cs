using Microsoft.Extensions.Logging;
using Microsoft.Maui.LifecycleEvents;

namespace Sofia_s_Ladybugs
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
                    fonts.AddFont("bulgarian.otf", "Bulgarian");
                });

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
