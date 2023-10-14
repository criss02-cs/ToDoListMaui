using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Google.Cloud.Firestore;

namespace ToDoListMaui.Models.UserAdapter
{
    internal interface IUserAdapter
    {
        User ToUser(DocumentSnapshot snapshot);
    }
}
