using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Google.Cloud.Firestore;

namespace ToDoListMaui.Models.UserAdapter
{
    internal class UserAdapter : IUserAdapter
    {
        public User ToUser(DocumentSnapshot snapshot)
        {
            var user = new User
            {
                Id = snapshot.GetValue<string>("id"),
                Name = snapshot.GetValue<string>("name"),
                Email = snapshot.GetValue<string>("email"),
                Joined = TimeSpan.FromSeconds(snapshot.GetValue<double>("joined"))
            };
            return user;
        }
    }
}
