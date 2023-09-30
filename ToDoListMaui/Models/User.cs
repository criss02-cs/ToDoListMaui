using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using JsonConverter = Newtonsoft.Json.JsonConverter;

namespace ToDoListMaui.Models
{
    public record User
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public TimeSpan Joined { get; set; }
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
