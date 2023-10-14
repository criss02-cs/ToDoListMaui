using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Firebase.Auth;
using ToDoListMaui.Models;

namespace ToDoListMaui.ViewModels
{
    public partial class ToDoListViewViewModel : BaseViewModel
    {
        public ObservableCollection<ToDoListItem> ToDoList { get; set; } = new ObservableCollection<ToDoListItem>();
        [ObservableProperty] private bool _showingNewItemView;
        public ToDoListViewViewModel(IFirebaseAuthClient auth) : base(auth)
        {
            _ = LoadItemsAsync();
        }


        private async Task LoadItemsAsync()
        {
            if (CurrentUserId is null) return;
            if (Db is null) await MainThread.InvokeOnMainThreadAsync(CreateFirestoreDbAsync);
            var collection = await Db.Collection($"users/{CurrentUserId}/todos").GetSnapshotAsync();
            ToDoList.Clear();
            foreach (var item in collection.Documents)
            {
                ToDoList.Add(item.ConvertTo<ToDoListItem>());
            }
        }

        [RelayCommand]
        public async Task Delete(string id)
        {
            await Db.Collection("users")
                .Document(CurrentUserId)
                .Collection("todos")
                .Document(id)
                .DeleteAsync();
        }
    }
}
