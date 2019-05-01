using System;
using Xamarin.Forms;
using Firebase.Database;
using Firebase.Database.Query;
using Todo.Helpers;

namespace Todo
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
            //await Navigation.PopAsync();

            var todoItem = (TodoItem)BindingContext;
            await firebaseHelper.AddTodo(todoItem);
            //Name.Text = string.Empty;
            //Priority.Text = string.Empty;
            //Done.IsToggled = false;
            //await DisplayAlert("Success", "Todo Added Successfully", "OK");
        }

		async void OnDeleteClicked(object sender, EventArgs e)
		{
			var todoItem = (TodoItem)BindingContext;
			await App.Database.DeleteItemAsync(todoItem);
			await Navigation.PopAsync();
		}

		async void OnCancelClicked(object sender, EventArgs e)
		{
			await Navigation.PopAsync();
		}

		void OnSpeakClicked(object sender, EventArgs e)
		{
			var todoItem = (TodoItem)BindingContext;
			DependencyService.Get<ITextToSpeech>().Speak(todoItem.Name + " " + todoItem.Notes);
		}
	}
}
