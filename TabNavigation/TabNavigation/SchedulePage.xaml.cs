using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace TabNavigation
{
    public partial class SchedulePage : ContentPage
    {
        public SchedulePage()
        {
            InitializeComponent();
        }

        async void OnUpcomingAppointmentsButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new UpcomingAppointmentsPage());
        }
    }
}
