using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Firebase.Auth;
using ToDoListMaui.Models;
using ToDoListMaui.Models.UserAdapter;
using DocumentSnapshot = Google.Cloud.Firestore.DocumentSnapshot;
using User = ToDoListMaui.Models.User;

namespace ToDoListMaui.ViewModels
{
    public partial class ProfileViewModel : BaseViewModel
    {
        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(ShowLoading))]
        private User _user = UserConstants.EmptyUser;
        public bool ShowLoading => User == UserConstants.EmptyUser;
        public ProfileViewModel(IFirebaseAuthClient auth) : base(auth)
        {
            FetchUserCommand.Execute(null);
        }

        [RelayCommand]
        private async Task FetchUser()
        {
            if (CurrentUserId is null) return;
            if (Db is null) await MainThread.InvokeOnMainThreadAsync(CreateFirestoreDbAsync); 
            var userSnapshot = await Db.Collection("users")
                .Document(CurrentUserId)
                .GetSnapshotAsync();
            if(userSnapshot == null) return;
            MainThread.BeginInvokeOnMainThread(() => CreateUserFromSnapshot(userSnapshot));
        }

        private async void CreateUserFromSnapshot(DocumentSnapshot snapshot)
        {
            try
            {
                var adapter = new UserAdapter();
                User = adapter.ToUser(snapshot);
                OnPropertyChanged(nameof(ShowLoading));
            }
            catch (Exception e)
            {
                await Application.Current.MainPage.DisplayAlert("", e.Message, "Ok");
            }
        }

        [RelayCommand]
        private async Task Logout()
        {
            try
            {
                Auth.SignOut();
            }
            catch (Exception e)
            {
                await Application.Current.MainPage.DisplayAlert("", e.Message, "Ok");
            }
        }
    }
}
