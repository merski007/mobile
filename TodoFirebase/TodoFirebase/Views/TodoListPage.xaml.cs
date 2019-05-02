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

            var allTodos = await firebaseHelper.GetAllTodos();
            listView.ItemsSource = allTodos;
        }

        async void OnItemAdded(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new TodoItemPage
            {
                BindingContext = new TodoItem()
            });
        }

        async void OnListItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                await Navigation.PushAsync(new TodoItemPage
                {
                    BindingContext = e.SelectedItem as TodoItem
                });
            }
        }
    }
}
