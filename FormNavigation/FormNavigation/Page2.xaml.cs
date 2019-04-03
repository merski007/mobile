using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace FormNavigation
{
    public partial class Page2 : ContentPage
    {
        public Page2(string name)
        {
            InitializeComponent();
            this.name.Text = name;
        }

        async void OnNextPageButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Page3());
        }

        async void OnPreviousPageButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}
