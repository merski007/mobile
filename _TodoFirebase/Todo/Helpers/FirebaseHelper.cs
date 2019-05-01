using System;
using System.Collections.Generic;
using System.Text;
using Firebase.Database;
using Firebase.Database.Query;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Todo.

namespace Todo.Helpers
{
    public class FirebaseHelper
    {
        FirebaseClient firebase = new FirebaseClient("https://todoappmobile-d7ea3.firebaseio.com/");

        public async Task<List<TodoItem>> GetAllTodos()
        {

            return (await firebase
              .Child("Todo")
              .OnceAsync<TodoItem>()).Select(item => new TodoItem
              {
                  Name = item.Object.Name,
                  Priority = item.Object.Priority,
                  Done = item.Object.Done
              }).ToList();
        }

        public async Task AddTodo(string name, int priority, Boolean done)
        {

            await firebase
              .Child("Todo")
              .PostAsync(new TodoItem() { Name = name, Priority = priority, Done = done });
        }

        public async Task AddTodo(TodoItem todo)
        {
            await firebase
              .Child("Todo")
              .PostAsync(new TodoItem() { Name = todo.Name, Priority = todo.Priority, Done = todo.Done });
        }

        //public async Task<TodoItem> GetTodo(string task)
        //{
        //    var allTodos = await GetAllTodos();
        //    await firebase
        //      .Child("Todo")
        //      .OnceAsync<TodoItem>();
        //    return allTodos.Where(a => a.Task == task).FirstOrDefault();
        //}

        //public async Task UpdateTodo(string task, Boolean done)
        //{
        //    var toUpdateTodo = (await firebase
        //      .Child("Todo")
        //      .OnceAsync<TodoItem>()).Where(a => a.Object.Task == task).FirstOrDefault();

        //    await firebase
        //      .Child("Todo")
        //      .Child(toUpdateTodo.Key)
        //      .PutAsync(new TodoItem() { Task = task, Done = done });
        //}

        //public async Task DeleteTodo(string task)
        //{
        //    var toDeleteTodo = (await firebase
        //      .Child("Todo")
        //      .OnceAsync<TodoItem>()).Where(a => a.Object.Task == task).FirstOrDefault();
        //    await firebase.Child("Todo").Child(toDeleteTodo.Key).DeleteAsync();

        //}
    }
}
