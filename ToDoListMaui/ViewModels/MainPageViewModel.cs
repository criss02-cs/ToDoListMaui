using CommunityToolkit.Mvvm.Input;
using Firebase.Auth;
using Google.Cloud.Firestore;
using ToDoListMaui.Views;

namespace ToDoListMaui.ViewModels
{
    public partial class MainPageViewModel : BaseViewModel
    {
        public bool IsSignedIn => Auth.User != null;

        public MainPageViewModel(IFirebaseAuthClient auth) : base(auth)
        {
            auth.AuthStateChanged += (sender, args) =>
            {
                MainThread.BeginInvokeOnMainThread(CheckUserLogged);
            };
        }

        private async void CheckUserLogged()
        {
            await OnAppearingAsync();
        }

        [RelayCommand]
        public async Task OnAppearingAsync()
        {
            if (IsSignedIn)
            {
                await Shell.Current.GoToAsync("//main");
            }
            else
            {
                await Shell.Current.GoToAsync("//Login");
            }
        }

    }
}
