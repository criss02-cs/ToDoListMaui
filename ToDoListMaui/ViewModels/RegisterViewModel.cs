using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Firebase.Auth;
using Google.Cloud.Firestore;
using ToDoListMaui.Models;
using User = ToDoListMaui.Models.User;

namespace ToDoListMaui.ViewModels
{
    public partial class RegisterViewModel : BaseViewModel
    {
        [ObservableProperty] private string _name;
        [ObservableProperty] private string _email;
        [ObservableProperty] private string _password;
        public RegisterViewModel(IFirebaseAuthClient auth) : base(auth)
        {
        }

        [RelayCommand]
        public async Task Register()
        {
            if (!Validate()) return;
            var response = await Auth.CreateUserWithEmailAndPasswordAsync(Email, Password);
            if (response != null && !string.IsNullOrEmpty(response.User.Uid))
            {
                await InsertUserRecordAsync(response.User.Uid);
            }
        }

        [RelayCommand]
        public async Task GoToLoginPage() => await Shell.Current.GoToAsync("//LoginPage");

        private async Task InsertUserRecordAsync(string id)
        {
            var joined = DateTime.UtcNow - new DateTime(1970, 1, 1);
            var newUser = new User { Email = Email, Id = id, Joined = joined };
            await Db
                .Collection("users")
                .Document(id)
                .SetAsync(newUser.AsDictionary());
        }


        private bool Validate()
        {
            if (string.IsNullOrWhiteSpace(Name) || string.IsNullOrEmpty(Email) || string.IsNullOrEmpty(Password))
            {
                return false;
            }

            if (!Email.Contains('@') && !Email.Contains('.'))
            {
                return false;
            }

            if (Password.Length < 7)
            {
                return false;
            }

            return true;
        }
    }
}
