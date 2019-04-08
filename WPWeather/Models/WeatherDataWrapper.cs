using System.Collections.Generic;
using WPWeather.Models;

namespace WPWeather
{
    public class WeatherDataWrapper
    {
        public City city { get; set; }

        public List<WeatherData> list { get; set; }
    }
}
