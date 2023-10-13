using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Google.Cloud.Firestore;

namespace ToDoListMaui.Models
{
    [FirestoreData]
    public class ToDoListItem
    {
        [FirestoreProperty]
        public string Id { get; set; }
        [FirestoreProperty]
        public string Title { get; set; }
        [FirestoreProperty]
        public TimeSpan DueDate { get; set; }
        [FirestoreProperty]
        public TimeSpan CreatedDate { get; set; }
        [FirestoreProperty]
        public bool IsDone { get; set; }
    }
}
