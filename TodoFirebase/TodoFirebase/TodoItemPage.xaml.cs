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

        async void OnSaveClicked(object sender, EventArgs e)
        {
            //var todoItem = (TodoItem)BindingContext;
            //await App.Database.SaveItemAsync(todoItem);

            var todoItem = new TodoItem();
            //var todoItem = (TodoItem)BindingContext;  //can't get the binding to work
            todoItem.Name = Name.Text;
            todoItem.Done = Done.IsToggled;
            await firebaseHelper.AddTodo(todoItem);
            //await Navigation.PopAsync();
        }
    }
}
