using Firebase.Auth;
using ToDoListMaui.ViewModels;

namespace ToDoListMaui
{
    public partial class MainPage : ContentPage
    {
        public MainPage(MainPageViewModel vm)
        {
            InitializeComponent();
            BindingContext = vm;
        }

        private void MainPage_OnAppearing(object sender, EventArgs e)
        {
            if (BindingContext is not MainPageViewModel vm) return;
            vm.AppearingCommand.Execute(null);
        }
    }
}