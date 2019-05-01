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
    public partial class FlavorsView : ContentPage
    {
        private ObservableCollection<Flavor> _flavors;

        public FlavorsView()
        {
            InitializeComponent();

            //App.Database.PopulateDb();

            InitializeFlavors();
        }

        public void InitializeFlavors()
        {
            IList<Flavor> tempList = new List<Flavor>();

            tempList = App.Database.GetItemsAsync().Result;

            _flavors = new ObservableCollection<Flavor>(tempList);

            FlavorList.ItemsSource = _flavors;
        }

        async void OnItemTappedAsync(object sender, ItemTappedEventArgs e)
        {
            if (e == null) return; // has been set to null, do not 'process' tapped event
            Debug.WriteLine("Tapped: " + e.Item);
            ((ListView)sender).SelectedItem = null; // de-select the row

            var flavor = e.Item as Flavor;
            await DisplayAlert("", flavor.Description, "Ok");
        }

    }
}
