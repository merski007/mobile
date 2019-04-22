using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FlashCards
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        async void OnStartButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new QuestionsPage());
        }

        //async void OnSwiped(object sender, EventArgs e)
        //{
        //    await Navigation.PushAsync(new QuestionsPage());
        //}

    }
}
