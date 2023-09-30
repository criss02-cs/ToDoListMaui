using CommunityToolkit.Mvvm.Input;
using Firebase.Auth;
using Plugin.Firebase.Auth;
using Plugin.Firebase.Firestore;
using ToDoListMaui.Views;

namespace ToDoListMaui.ViewModels
{
    public partial class MainPageViewModel : BaseViewModel
    {
        public bool IsSignedIn => Auth.CurrentUser != null;

        public MainPageViewModel(IFirebaseAuth auth, IFirebaseFirestore db) : base(auth, db)
        {
        }

        [RelayCommand]
        public async Task OnAppearingAsync()
        {
            if (IsSignedIn)
            {
                await Shell.Current.GoToAsync(nameof(AccountView));
            }
            else
            {
                await Shell.Current.GoToAsync(nameof(LoginPage));
            }
        }

    }
}
