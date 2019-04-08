using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPWeather.ViewModels
{
    public class DayViewModel
    {
        public string DayOfTheWeek { get; set; }
        public string TypeOfDayImagePath { get; set; }
        public string Temperature { get; set; }
        public string TypeOfDay { get; set; }


        public DayViewModel()
        {
            DayOfTheWeek = "Monday";
            TypeOfDayImagePath = "pack://application:,,,/Images/cloudy.png";
            Temperature = "16 C";
            TypeOfDay = "Cloudy";
        }
    }
}
