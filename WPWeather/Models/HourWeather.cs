using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPWeather.Models
{
    public class HourWeather
    {
        public string Hour { get; set; }
        public string TypeOfDayImagePath { get; set; }
        public string TypeOfDay { get; set; }

        public HourWeather()
        {
            Hour = "16:00";
            TypeOfDayImagePath = "pack://application:,,,/Images/cloudy.png";
            TypeOfDay = "Cloudy";
        }
    }
}
