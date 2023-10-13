using CommunityToolkit.Maui;
using Firebase.Auth;
using Firebase.Auth.Providers;
using Google.Apis.Auth.OAuth2;
using Google.Cloud.Firestore;
using Microsoft.Extensions.Logging;
using ToDoListMaui.ViewModels;
using ToDoListMaui.Views;

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
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                    fonts.AddFont("fa-brands-400.ttf", "FaBrands");
                    fonts.AddFont("fa-solid-900.ttf", "FaSolid");
                    fonts.AddFont("TT-Commons-Bold.otf", "TTCommonsBold");
                });
            builder.RegisterFirebase();
            builder.RegisterViewModels();
            builder.RegisterPages();
#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }

        private static MauiAppBuilder RegisterViewModels(this MauiAppBuilder builder)
        {
            builder.Services.AddSingleton<MainPageViewModel>();
            builder.Services.AddTransient<LoginViewModel>();
            builder.Services.AddTransient<RegisterViewModel>();
            builder.Services.AddTransient<RegisterViewModel>();
            builder.Services.AddTransient<ToDoListViewViewModel>();
            builder.Services.AddTransient<ProfileViewModel>();
            return builder;
        }

        private static MauiAppBuilder RegisterPages(this MauiAppBuilder builder)
        {
            builder.Services.AddSingleton<MainPage>();
            builder.Services.AddTransient<LoginPage>();
            builder.Services.AddTransient<RegisterPage>();
            builder.Services.AddTransient<ToDoListViewPage>();
            builder.Services.AddTransient<ProfileViewPage>();
            return builder;
        }

        private static MauiAppBuilder RegisterFirebase(this MauiAppBuilder builder)
        {
            var config = new FirebaseAuthConfig
            {
                ApiKey = "AIzaSyA6T2O0Bgq6DYUrzASJffeivMQtWTkysO0",
                AuthDomain = "todolist-e06c5.firebaseapp.com",
                Providers = new FirebaseAuthProvider[]
                {
                    new EmailProvider()
                }
            };
            builder.Services.AddSingleton<IFirebaseAuthClient>(new FirebaseAuthClient(config));
            return builder;
        }
    }
}