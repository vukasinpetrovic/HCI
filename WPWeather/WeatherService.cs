using System.Net;

namespace WPWeather
{
    public static class WeatherService
    {
        private static string API_KEY = "&appid=d066ac463036d6bdda95e0eea80b13b8";
        
        public static string get5DayForecastForCityID(string city)
        {
            var client = new WebClient();
            var response = client.DownloadString("http://api.openweathermap.org/data/2.5/forecast?id=" + city + API_KEY);

            return response;
        }

        public static string get5DayForecastForCityName(string city)
        {
            var client = new WebClient();
            var response = client.DownloadString("http://api.openweathermap.org/data/2.5/weather?q=" + city + API_KEY);

            return response;
        }

        public static string getForecastByHoursForCity(string city)
        {
            var client = new WebClient();
            var response = client.DownloadString("http://api.openweathermap.org/data/2.5/forecast/hourly?id=" + city + API_KEY);

            return response;
        }
    }
}