using Newtonsoft.Json;

namespace WPWeather.Models
{
    public class Rain
    {
        [JsonProperty(PropertyName = "3h")]
        public double h3 { get; set; }
    }
}
