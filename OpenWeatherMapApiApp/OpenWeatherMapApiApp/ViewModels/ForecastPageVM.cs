using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using MvvmHelpers.Commands;
using OpenWeatherMapApiApp.Models;
using OpenWeatherMapApiApp.Services;
using Xamarin.Forms;

namespace OpenWeatherMapApiApp.ViewModels
{
    public class ForecastPageVM : INotifyPropertyChanged
    {
        private IWeatherService WeatherService = new OpenWeatherService();


        private string citylabel;
        private string cityentry;
        private string temperaturelabel;
        private string nemlabel;
        private string description;
        private string temp_min;
        private string temp_max;
        private double nem;
        private string imgstr;

        public string imgstring
        {
            get { return imgstr;}
            set { imgstr = value; OnPropertyChanged("imgstring"); }
        }

        public double Nem
        {
            get { return nem; }
            set { nem = value; OnPropertyChanged("Nem"); }
        }

        public string crtcity;

        public string CityLabel
        {
            get { return citylabel; }
            set { citylabel = value; OnPropertyChanged("CityLabel"); }
        }
        public string Description
        {
            get { return description; }
            set { description = value; OnPropertyChanged("Description"); }
        }

        public string TempMin
        {
            get { return temp_min; }
            set { temp_min = value; OnPropertyChanged("TempMin"); }

        }

        public string TempMax
        {
            get { return temp_max; }
            set { temp_max = value; OnPropertyChanged("TempMax"); }
        }


        public string TemperatureLabe
        {
            get { return temperaturelabel; }
            set { temperaturelabel = value; OnPropertyChanged("TemperatureLabe"); }
        }


        public string NemLabel
        {
            get { return nemlabel; }
            set { nemlabel = value; OnPropertyChanged("NemLabel"); }
        }

        public WeatherForecast.Root CurrentForecast { get; set; }

        public WeatherForecast.Main mainClass  { get; set; }

        public AsyncCommand getforecastcommand { get; }

        public string CityEntry
        {
            get { return cityentry; }
            set
            {
                cityentry = value; OnPropertyChanged("CityEntry");

            }
        }

        public ForecastPageVM()
        {
            getforecastcommand = new AsyncCommand(GetForecast);
        }



        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        public async Task GetForecast()
        {
           
            CurrentForecast  = await WeatherService.GetForecastAsync(CityEntry);

            int caseswitch = CurrentForecast.weather[0].id / 100;

            crtcity = CityEntry;

            CityLabel = crtcity;
            TemperatureLabe = CurrentForecast.main.temp.ToString() + "°";

            Nem = CurrentForecast.main.humidity;

            Description =  CurrentForecast.weather[0].description;
            NemLabel =   CurrentForecast.main.humidity.ToString();

            switch (caseswitch)
            {
                case (2):
                    imgstring = "thunder.gif";
                    break;
                case (3):
                    imgstring = "yagmur.gif";
                    break;
                case (5):
                    imgstring = "yagmur.gif";
                    break;
                case (6):
                    imgstring = "snow.gif";
                    break;
                case (7):
                    imgstring = "foggy.gif";
                    break;
                case (8):
                    imgstring = "cloudy.gif";
                    break;
                    
            }













        }


    }
}
