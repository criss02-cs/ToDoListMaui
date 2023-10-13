using Plugin.Firebase.Auth;

namespace ToDoListMaui
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            MainPage = new AppShell();
        }
    }
}