using OpenWeatherMapApiApp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OpenWeatherMapApiApp.Services
{
    public interface IWeatherService
    {
      Task<WeatherForecast.Root> GetForecastAsync(string location);
        
    }
}
