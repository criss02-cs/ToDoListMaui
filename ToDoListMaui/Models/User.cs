using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Google.Cloud.Firestore;
using JsonConverter = Newtonsoft.Json.JsonConverter;

namespace ToDoListMaui.Models
{
    [FirestoreData]
    public class User
    {
        [FirestoreProperty("id")]
        public string Id { get; set; }
        [FirestoreProperty("name")]
        public string Name { get; set; }
        [FirestoreProperty("email")]
        public string Email { get; set; }
        // todo capire come convertire da double a timespan quando legge da firebase
        [FirestoreProperty("joined")]
        public TimeSpan Joined { get; set; }
    }

    public static class UserConstants
    {
        public static User EmptyUser { get; } = new User();
    }

    public static class Extensions
    {
        public static Dictionary<string, object> AsDictionary(this User user)
        {
            try
            {
                var data = JsonConvert.SerializeObject(user);
                var json = JsonConvert.DeserializeObject<Dictionary<string, object>>(data);
                return json;
            }
            catch (Exception)
            {
                return new Dictionary<string, object>();
            }
        }
    }
}
