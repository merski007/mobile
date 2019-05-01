using System;
using System.Diagnostics;
using Xamarin.Forms;
using Firebase.Database;
using Firebase.Database.Query;
using ToDoFirebase.Helpers;
using ToDoFirebase.Models;

namespace ToDoFirebase.Views
{
    public partial class ToDoListPage : ContentPage
    {
        FirebaseHelper firebaseHelper = new FirebaseHelper();

        public ToDoListPage()
        {
            InitializeComponent();
        }

        // from original ToDo app
        //protected override async void OnAppearing()
        //{
        //    base.OnAppearing();

        //    // Reset the 'resume' id, since we just want to re-start here
        //    ((App)App.Current).ResumeAtTodoId = -1;
        //    lstToDos.ItemsSource = await App.Database.GetItemsAsync();
        //}

        //might need to move this to the ListPage
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            var allToDos = await firebaseHelper.GetAllToDos();
            lstToDos.ItemsSource = allToDos;
        }
    }
}
