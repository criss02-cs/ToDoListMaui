using Plugin.Firebase.Auth;

namespace ToDoListMaui
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

#if IOS
            FirebaseAuthImplementation.Initialize();
#elif ANDROID
            FirebaseAuthImplementation.Initialize("AIzaSyA6T2O0Bgq6DYUrzASJffeivMQtWTkysO0");
#endif

            MainPage = new AppShell();
        }
    }
}