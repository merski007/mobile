using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FOTD.Models;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace FOTD
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        async void OnStartButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new FlavorsView());
        }
    }
}
