using System.Net.Http.Json;
using System.Text.Json.Serialization;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Firebase.Auth;
using Newtonsoft.Json;
using ToDoListMaui.Views;

namespace ToDoListMaui.ViewModels
{
    public partial class LoginViewModel : BaseViewModel
    {
        [ObservableProperty] private string _email;
        [ObservableProperty] private string _password;
        [ObservableProperty] private string _errorMessage;
        public LoginViewModel(IFirebaseAuthClient auth) : base(auth)
        {
        }

        [RelayCommand]
        public async Task Login()
        {
            if (!Validate()) return;
            // try login
            try
            {
                _ = await Auth.SignInWithEmailAndPasswordAsync(Email.Trim().ToLower(), Password);
            }
            catch (Exception e)
            {
                await Application.Current.MainPage.DisplayAlert("",e.Message, "Ok");
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
            await Shell.Current.GoToAsync("//Login");
        }
    }
}
