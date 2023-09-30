using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using Microsoft.Maui.LifecycleEvents;
using Plugin.Firebase.Auth;
using Plugin.Firebase.Bundled.Shared;
using Plugin.Firebase.Firestore;
using ToDoListMaui.ViewModels;
using ToDoListMaui.Views;
#if IOS
using Plugin.Firebase.Bundled.Platforms.iOS;
#else
using Plugin.Firebase.Bundled.Platforms.Android;
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

            //builder.Services.AddSingleton<IFirebaseAuth>(new FirebaseAuthImplementation());
            //builder.Services.AddSingleton<IFirebaseFirestore>(new FirebaseFirestoreImplementation());
            builder.Services.AddSingleton<MainPageViewModel>();
            builder.Services.AddTransient<LoginViewModel>();
            builder.Services.AddTransient<RegisterViewModel>();
            
            builder.Services.AddSingleton<MainPage>();
            builder.Services.AddTransient<AccountView>();
            builder.Services.AddTransient<LoginPage>();
            builder.Services.AddTransient<RegisterPage>();

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
                events.AddiOS(iOS => iOS.FinishedLaunching((app, launchOptions) =>
                {
                    CrossFirebase.Initialize(CreateCrossFirebaseSettings());
                    return false;
                }));
#else
                events.AddAndroid(android => android.OnCreate((activity, _) =>
                    CrossFirebase.Initialize(activity, CreateCrossFirebaseSettings())));
#endif
            });
            builder.Services.AddSingleton(_ => CrossFirebaseAuth.Current);
            builder.Services.AddSingleton(_ => CrossFirebaseFirestore.Current);
            return builder;
        }


        private static CrossFirebaseSettings CreateCrossFirebaseSettings()
        {
            var settings = new CrossFirebaseSettings(
                isAnalyticsEnabled: false,
                isAuthEnabled: true,
                isCloudMessagingEnabled: false,
                isDynamicLinksEnabled: false,
                isFirestoreEnabled: true,
                isFunctionsEnabled: false,
                isRemoteConfigEnabled: false,
                isStorageEnabled: false,
                googleRequestIdToken: "537235599720-723cgj10dtm47b4ilvuodtp206g0q0fg.apps.googleusercontent.com");
            return settings;
        }
    }
}