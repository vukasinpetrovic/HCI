using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Device.Location;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPWeather
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            GeoCoordinateWatcher watcher = new GeoCoordinateWatcher();

            // Do not suppress prompt, and wait 1000 milliseconds to start.
            watcher.TryStart(false, TimeSpan.FromMilliseconds(1000));

            GeoCoordinate coord = watcher.Position.Location;

            if (coord.IsUnknown != true)
            {
                Perica.Text = string.Format("Lat: {0}, Long: {1}", coord.Latitude, coord.Longitude);
            }
            else
            {
                Perica.Text = ("Unknown latitude and longitude.");
            }


            //List<City> cities;
            //using (StreamReader file = File.OpenText(@"D:/city.list.json"))
            //{
            //    JsonSerializer serializer = new JsonSerializer();
            //    cities = (List<City>)serializer.Deserialize(file, typeof(List<City>));
            //}

            //Perica.Text = WeatherService.get5DayForecastForCityName("Belgrade");
        }
    }
}
