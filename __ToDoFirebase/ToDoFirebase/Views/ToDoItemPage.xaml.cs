using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Firebase.Database;
using Firebase.Database.Query;
using ToDoFirebase.Helpers;
using ToDoFirebase.Models;

namespace ToDoFirebase.Views
{
    public partial class ToDoItemPage : ContentPage
    {
        FirebaseHelper firebaseHelper = new FirebaseHelper();

        public ToDoItemPage()
        {
            InitializeComponent();
        }


        // might need to move this to the ListPage
        //protected async override void OnAppearing()
        //{

        //    base.OnAppearing();
        //    var allToDos = await firebaseHelper.GetAllToDos();
        //    lstToDos.ItemsSource = allToDos;
        //}

        private async void OnSaveClicked(object sender, EventArgs e)
        {
            await firebaseHelper.AddToDo(Name.Text, Convert.ToInt32(Priority.Text), Done.IsToggled);
            Name.Text = string.Empty;
            Priority.Text = string.Empty;
            Done.IsToggled = false;
            await DisplayAlert("Success", "ToDo Added Successfully", "OK");

            // this comes from the setting up the original view, it would display the list under the add person section
            // should be able to leave it off
            //var allToDos = await firebaseHelper.GetAllToDos();
            //lstToDos.ItemsSource = allToDos;
        }

        //async void OnSaveClicked(object sender, EventArgs e)
        //{
        //    var todoItem = (ToDoItem)BindingContext;
        //    await App.Database.SaveItemAsync(todoItem);
        //    await Navigation.PopAsync();
        //}

        //async void OnDeleteClicked(object sender, EventArgs e)
        //{
        //    var todoItem = (ToDoItem)BindingContext;
        //    await App.Database.DeleteItemAsync(todoItem);
        //    await Navigation.PopAsync();
        //}

        //async void OnCancelClicked(object sender, EventArgs e)
        //{
        //    await Navigation.PopAsync();
        //}

        //void OnSpeakClicked(object sender, EventArgs e)
        //{
        //    var todoItem = (ToDoItem)BindingContext;
        //    DependencyService.Get<ITextToSpeech>().Speak(todoItem.Name + " " + todoItem.Notes);
        //}
    }
}
