using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPWeather.Models;

namespace WPWeather.ViewModels
{
    public class HourlyViewModel
    {
        public ObservableCollection<HourWeather> HourlyWeather { get; set; }

        public HourlyViewModel()
        {
            //HourlyWeather = new ObservableCollection<HourWeather>();

            //HourlyWeather.Add(new HourWeather());
            //HourlyWeather.Add(new HourWeather());
            //HourlyWeather.Add(new HourWeather());
            //HourlyWeather.Add(new HourWeather());
            //HourlyWeather.Add(new HourWeather());
            //HourlyWeather.Add(new HourWeather());
            //HourlyWeather.Add(new HourWeather());
            //HourlyWeather.Add(new HourWeather());
        }
    }
}
