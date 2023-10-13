using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using Firebase.Auth;
using Google.Cloud.Firestore;

namespace ToDoListMaui.ViewModels
{
    public partial class BaseViewModel : ObservableObject
    {
        protected IFirebaseAuthClient Auth { get; private set; }
        protected FirestoreDb Db { get; private set; }
        protected BaseViewModel(IFirebaseAuthClient auth)
        {
            Auth = auth;
            _ = CreateFirestoreDbAsync();
        }


        private async Task CreateFirestoreDbAsync()
        {
            var localPath = Path.Combine(FileSystem.CacheDirectory, "credentials.json");
            await using var json = await FileSystem.OpenAppPackageFileAsync("credentials.json");
            await using var dest = File.Create(localPath);
            await json.CopyToAsync(dest);
            Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", localPath);
            dest.Close();
            Db = FirestoreDb.Create("todolist-e06c5");
        }

        protected string CurrentUserId => Auth?.User?.Uid ?? "";
    }
}
