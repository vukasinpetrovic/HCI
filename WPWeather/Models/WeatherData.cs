using System.Collections.Generic;

namespace WPWeather.Models
{
    public class WeatherData
    {
        public int dt { get; set; }
        public string dt_txt { get; set; }
        public Main main { get; set; }
        public List<Weather> weather { get; set; }
        public Clouds clouds { get; set; }
        public Wind wind { get; set; }
        public Rain rain { get; set; }
    }
}
