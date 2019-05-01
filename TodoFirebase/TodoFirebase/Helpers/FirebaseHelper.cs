using System;
using System.Collections.Generic;
using System.Text;
using Firebase.Database;
using Firebase.Database.Query;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace TodoFirebase
{
    public class FirebaseHelper
    {
        FirebaseClient firebase = new FirebaseClient("https://todoappmobile-d7ea3.firebaseio.com/");

        public async Task<List<TodoItem>> GetAllTodos()
        {
            return (await firebase
              .Child("TodoItem")
              .OnceAsync<TodoItem>()).Select(item => new TodoItem
              {
                  Name = item.Object.Name,
                  Priority = item.Object.Priority,
                  Done = item.Object.Done
              }).ToList();
        }

        public async Task AddTodo(TodoItem todo)
        {
            await firebase
              .Child("TodoItem")
              .PostAsync(new TodoItem(todo));
        }

    }
}
