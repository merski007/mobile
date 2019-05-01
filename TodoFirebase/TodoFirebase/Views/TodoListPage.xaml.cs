using System;
using System.Collections.Generic;
using Firebase.Database;
using Firebase.Database.Query;
using Xamarin.Forms;

namespace TodoFirebase
{
    public partial class TodoListPage : ContentPage
    {
        FirebaseHelper firebaseHelper = new FirebaseHelper();

        public TodoListPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            // Reset the 'resume' id, since we just want to re-start here
            //((App)App.Current).ResumeAtTodoId = -1;
            //listView.ItemsSource = await App.Database.GetItemsAsync();

            var allTodos = await firebaseHelper.GetAllTodos();
            listView.ItemsSource = allTodos;
        }
    }
}
