using System;
using System.Collections.Generic;
using Firebase.Database;
using Firebase.Database.Query;
using Xamarin.Forms;

namespace TodoFirebase
{
    public partial class TodoItemPage : ContentPage
    {
        FirebaseHelper firebaseHelper = new FirebaseHelper();
       

        public TodoItemPage()
        {
            InitializeComponent();
        }

        private async void OnSaveClicked(object sender, EventArgs e)
        {
            var todoItem = new TodoItem();
            todoItem.Name = Name.Text;
            todoItem.Priority = Convert.ToInt32(Priority.Text);
            todoItem.Done = Done.IsToggled;
            await firebaseHelper.AddTodo(todoItem);
            await Navigation.PopAsync();
        }

    }
}
