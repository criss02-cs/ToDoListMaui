using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using Plugin.Firebase.Auth;

namespace ToDoListMaui.ViewModels
{
    public partial class BaseViewModel : ObservableObject
    {
        protected IFirebaseAuth Auth { get; private set; }
        protected BaseViewModel(IFirebaseAuth auth)
        {
            Auth = auth;
        }

        protected string CurrentUserId => Auth?.CurrentUser.Uid ?? "";
    }
}
