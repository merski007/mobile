using System;
using System.Collections.Generic;
using System.Text;
using ToDoFirebase.Models;
using Firebase.Database;
using Firebase.Database.Query;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ToDoFirebase.Helpers
{
    public class FirebaseHelper
    {
        FirebaseClient firebase = new FirebaseClient("https://todoappmobile-d7ea3.firebaseio.com/");

        public async Task<List<Person>> GetAllPersons()
        {

            return (await firebase
              .Child("Persons")
              .OnceAsync<Person>()).Select(item => new Person
              {
                  Name = item.Object.Name,
                  PersonId = item.Object.PersonId
              }).ToList();
        }

        public async Task AddPerson(int personId, string name)
        {

            await firebase
              .Child("Persons")
              .PostAsync(new Person() { PersonId = personId, Name = name });
        }

        public async Task<Person> GetPerson(int personId)
        {
            var allPersons = await GetAllPersons();
            await firebase
              .Child("Persons")
              .OnceAsync<Person>();
            return allPersons.Where(a => a.PersonId == personId).FirstOrDefault();
        }

        public async Task UpdatePerson(int personId, string name)
        {
            var toUpdatePerson = (await firebase
              .Child("Persons")
              .OnceAsync<Person>()).Where(a => a.Object.PersonId == personId).FirstOrDefault();

            await firebase
              .Child("Persons")
              .Child(toUpdatePerson.Key)
              .PutAsync(new Person() { PersonId = personId, Name = name });
        }

        public async Task DeletePerson(int personId)
        {
            var toDeletePerson = (await firebase
              .Child("Persons")
              .OnceAsync<Person>()).Where(a => a.Object.PersonId == personId).FirstOrDefault();
            await firebase.Child("Persons").Child(toDeletePerson.Key).DeleteAsync();

        }

        //
        // ToDo stuff underneath here
        //

        public async Task<List<ToDoItem>> GetAllToDos()
        {

            return (await firebase
              .Child("ToDo")
              .OnceAsync<ToDoItem>()).Select(item => new ToDoItem
              {
                  Name = item.Object.Name,
                  Priority = item.Object.Priority,
                  Done = item.Object.Done
              }).ToList();
        }

        public async Task AddToDo(string name, int priority, Boolean done)
        {

            await firebase
              .Child("ToDo")
              .PostAsync(new ToDoItem() { Name = name, Priority = priority, Done = done });
        }

        //public async Task<ToDoItem> GetToDo(string task)
        //{
        //    var allToDos = await GetAllToDos();
        //    await firebase
        //      .Child("ToDo")
        //      .OnceAsync<ToDoItem>();
        //    return allToDos.Where(a => a.Task == task).FirstOrDefault();
        //}

        //public async Task UpdateToDo(string task, Boolean done)
        //{
        //    var toUpdateToDo = (await firebase
        //      .Child("ToDo")
        //      .OnceAsync<ToDoItem>()).Where(a => a.Object.Task == task).FirstOrDefault();

        //    await firebase
        //      .Child("ToDo")
        //      .Child(toUpdateToDo.Key)
        //      .PutAsync(new ToDoItem() { Task = task, Done = done });
        //}

        //public async Task DeleteToDo(string task)
        //{
        //    var toDeleteToDo = (await firebase
        //      .Child("ToDo")
        //      .OnceAsync<ToDoItem>()).Where(a => a.Object.Task == task).FirstOrDefault();
        //    await firebase.Child("ToDo").Child(toDeleteToDo.Key).DeleteAsync();

        //}
    }
}
