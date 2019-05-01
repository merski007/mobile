using System;
using System.IO;
using FOTD.Data;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FOTD
{
    public partial class App : Application
    {
        static FlavorDb _database;

        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());
        }

        public static FlavorDb Database
        {
            get
            {
                if (_database == null)
                {
                    _database = new FlavorDb(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "FlavorSQLite.db3"));
                }
                return _database;
            }
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
