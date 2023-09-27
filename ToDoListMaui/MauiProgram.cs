using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using Microsoft.Maui.LifecycleEvents;
using Plugin.Firebase.Auth;
using Plugin.Firebase.Bundled.Shared;
using ToDoListMaui.ViewModels;
using ToDoListMaui.Views;
#if IOS
using Plugin.Firebase.Core.Platforms.iOS;
#else
using Plugin.Firebase.Core.Platforms.Android;
#endif

namespace ToDoListMaui
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .RegisterFirebaseServices()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            builder.Services.AddSingleton<IFirebaseAuth>(new FirebaseAuthImplementation());
            builder.Services.AddSingleton<MainPageViewModel>();
            
            builder.Services.AddSingleton<MainPage>();
            builder.Services.AddTransient<AccountView>();
            builder.Services.AddTransient<LoginPage>();

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }

        private static MauiAppBuilder RegisterFirebaseServices(this MauiAppBuilder builder)
        {
            builder.ConfigureLifecycleEvents(events =>
            {
#if IOS
                events.AddiOS(iOS => iOS.FinishedLaunching((_, _) =>
                {
                    CrossFirebase.Initialize();
                    return false;
                }));
#else
                events.AddAndroid(android => android.OnCreate((activity, _) =>
                    CrossFirebase.Initialize(activity)));
#endif
            });
            builder.Services.AddSingleton(_ => CrossFirebaseAuth.Current);
            return builder;
        }
    }
}