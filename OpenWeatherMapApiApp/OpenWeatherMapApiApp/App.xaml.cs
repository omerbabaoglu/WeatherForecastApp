using System;
using OpenWeatherMapApiApp.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace OpenWeatherMapApiApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new ForecastPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
