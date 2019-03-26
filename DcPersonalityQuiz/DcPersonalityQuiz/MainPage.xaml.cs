using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace DcPersonalityQuiz
{
    public static class AppConstants
    {
        // static color
        public static readonly Color BackgroundColor = Color.Navy;
    }

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
    }
}
