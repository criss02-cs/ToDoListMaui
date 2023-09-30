using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Plugin.Firebase.Auth;
using Plugin.Firebase.Firestore;
using ToDoListMaui.Views;

namespace ToDoListMaui.ViewModels
{
    public partial class LoginViewModel : BaseViewModel
    {
        [ObservableProperty] private string _email;
        [ObservableProperty] private string _password;
        [ObservableProperty] private string _errorMessage;
        public LoginViewModel(IFirebaseAuth auth, IFirebaseFirestore db) : base(auth, db)
        {
        }

        [RelayCommand]
        public async Task Login()
        {
            if (!Validate()) return;
            // try login
            var user = await Auth.SignInWithEmailAndPasswordAsync(Email, Password, false);

            if (!string.IsNullOrEmpty(CurrentUserId))
            {
                await Shell.Current.GoToAsync(nameof(MainPage));
            }
        }


        private bool Validate()
        {
            ErrorMessage = "";
            if (string.IsNullOrEmpty(Email.Trim()) && string.IsNullOrEmpty(Password.Trim()))
            {
                ErrorMessage = "Please fill in all fields.";
                return false;
            }

            if (Email.Contains('@') || Email.Contains('.')) return true;
            ErrorMessage = "Please enter valid email.";
            return false;

        }

        [RelayCommand]
        public async Task GoToRegisterPage()
        {
            await Shell.Current.GoToAsync(nameof(RegisterPage));
        }
    }
}
