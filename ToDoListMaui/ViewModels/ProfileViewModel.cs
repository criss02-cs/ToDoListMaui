using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Firebase.Auth;
using ToDoListMaui.Models;
using User = ToDoListMaui.Models.User;

namespace ToDoListMaui.ViewModels
{
    public partial class ProfileViewModel : BaseViewModel
    {
        [ObservableProperty] private User _user = UserConstants.EmptyUser;
        public ProfileViewModel(IFirebaseAuthClient auth) : base(auth)
        {
            FetchUserCommand.Execute(null);
        }

        [RelayCommand]
        public async Task FetchUser()
        {
            if (CurrentUserId is null) return;
            var userSnapshot = await Db.Collection("users")
                .Document(CurrentUserId)
                .GetSnapshotAsync();
            if(userSnapshot == null) return;
            MainThread.BeginInvokeOnMainThread(() =>
            {
                var user = userSnapshot.ConvertTo<User>();
                User = user;
            });
        }

        [RelayCommand]
        public async Task Logout()
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
