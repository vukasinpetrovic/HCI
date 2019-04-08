using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Windows;

namespace WPWeather
{
    public static class WeatherService
    {
        private static string API_KEY = "&appid=d066ac463036d6bdda95e0eea80b13b8";
        
        public static WeatherDataWrapper get5DayForecastByCityID(string cityID)
        {
            try
            {
                var client = new WebClient();
                var response = client.DownloadString("http://api.openweathermap.org/data/2.5/forecast?id=" + cityID + API_KEY);

                return JsonConvert.DeserializeObject<WeatherDataWrapper>(response);
            }
            catch (Exception e)
            {
                MessageBox.Show("Desila se greška: " + e.Message, "Obaveštenje", MessageBoxButton.OK, MessageBoxImage.Warning);
                return null;
            }
        }

        public static WeatherDataWrapper get5DayForecastByCityName(string city)
        {
            try
            {
                var client = new WebClient();
                var response = client.DownloadString("http://api.openweathermap.org/data/2.5/forecast?q=" + city + API_KEY);

                return JsonConvert.DeserializeObject<WeatherDataWrapper>(response);
            }
            catch (Exception e)
            {
                MessageBox.Show("Desila se greška: " + e.Message, "Obaveštenje", MessageBoxButton.OK, MessageBoxImage.Warning);
                return null;
            }
        }

        public static WeatherDataWrapper get5DayForecastByCityLocation(double lat, double lon)
        {
            try
            {
                var client = new WebClient();
                var response = client.DownloadString("http://api.openweathermap.org/data/2.5/forecast?lat=" + lat + "&lon=" + lon + API_KEY);

                return JsonConvert.DeserializeObject<WeatherDataWrapper>(response);
            }
            catch (Exception e)
            {
                MessageBox.Show("Desila se greška: " + e.Message, "Obaveštenje", MessageBoxButton.OK, MessageBoxImage.Warning);
                return null;
            }
        }

        public static WeatherDataWrapper getForecastByHoursForCityID(string cityID)
        {
            try
            {
                var client = new WebClient();
                var response = client.DownloadString("http://api.openweathermap.org/data/2.5/forecast/hourly?id=" + cityID + API_KEY);

                return JsonConvert.DeserializeObject<WeatherDataWrapper>(response);
            }
            catch (Exception e)
            {
                MessageBox.Show("Desila se greška: " + e.Message, "Obaveštenje", MessageBoxButton.OK, MessageBoxImage.Warning);
                return null;
            }
        }

        public static void saveCityToBookmark(int cityID)
        {
            using (StreamWriter sr = File.AppendText(Directory.GetCurrentDirectory() + "/city_bookmark.txt"))
            {
                sr.WriteLine(cityID.ToString());
                sr.Close();
            }
        }

        public static List<string> loadCitiesToBookmark()
        {
            List<string> cityIDs = new List<string>();
            using(StreamReader sr = File.OpenText(Directory.GetCurrentDirectory() + "/city_bookmark.txt"))
            {
                String s = "";
                while ((s = sr.ReadLine()) != null)
                {
                    cityIDs.Add(s);
                }
            }

            return cityIDs;
        }
    }
}