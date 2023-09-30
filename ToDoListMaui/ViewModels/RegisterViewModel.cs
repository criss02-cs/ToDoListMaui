using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Plugin.Firebase.Auth;
using Plugin.Firebase.Firestore;
using ToDoListMaui.Models;

namespace ToDoListMaui.ViewModels
{
    public partial class RegisterViewModel : BaseViewModel
    {
        [ObservableProperty] private string _name;
        [ObservableProperty] private string _email;
        [ObservableProperty] private string _password;
        public RegisterViewModel(IFirebaseAuth auth, IFirebaseFirestore db) : base(auth, db)
        {
        }

        [RelayCommand]
        public async Task Register()
        {
            if (!Validate()) return;
            var user = await Auth.CreateUserAsync(Email, Password);
            if (user != null && !string.IsNullOrEmpty(user.Uid))
            {
                InsertUserRecord(user.Uid);
            }
        }

        private void InsertUserRecord(string id)
        {
            var joined = DateTime.UtcNow - new DateTime(1970, 1, 1);
            var newUser = new User { Email = Email, Id = Guid.Parse(id), Joined = joined };
            Db.GetCollection("users")
                .GetDocument(id)
                .SetDataAsync(newUser.AsDictionary());
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
