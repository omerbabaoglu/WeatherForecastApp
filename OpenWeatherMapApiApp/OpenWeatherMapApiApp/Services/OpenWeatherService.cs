
using Newtonsoft.Json;
using OpenWeatherMapApiApp.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static OpenWeatherMapApiApp.Models.WeatherForecast;

namespace OpenWeatherMapApiApp.Services
{
    public class OpenWeatherService : IWeatherService
    {
        
        private const string APP_ID = "94b34ec41eb75be70b4e21724b6f8888";
        private HttpClient client;
        public WeatherForecast.Root Forecasts;

        public OpenWeatherService()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri("https://api.openweathermap.org/data/2.5/"); 
        }


        public async Task<WeatherForecast.Root> GetForecastAsync(string location)
        {
            if (location == null) throw new ArgumentNullException("Location can't be null");
            if (location == string.Empty) throw new ArgumentException("Location can't be an empty string.");

            var query = $"weather?q={location}&units=metric&appid={APP_ID}&lang=Tr";
           // var response = await client.GetAsync(query);
           // var content = await response.Content.ReadAsStringAsync();



            try
            {
                var response = await client.GetAsync(query);
                var content = await response.Content.ReadAsStringAsync();
                Forecasts = new WeatherForecast.Root();
                Forecasts = JsonConvert.DeserializeObject<Root>(content); 
                 

                //Forecasts = JsonConvert.DeserializeObject<WeatherForecast>(content);

            }
            catch (Exception ex)
            {
                Debug.WriteLine("/tError" + ex.Message);
                
            }
            return Forecasts;

           



        }

      
    }
}
