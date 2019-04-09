using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPWeather.Other;

namespace WPWeather.Models
{
    public class HourWeather : Data
    {
        private string _hour { get; set; }
        private string _temperature { get; set; }
        private string _typeOfDayImagePath { get; set; }
        private string _typeOfDay { get; set; }

        public string Hour
        {
            get
            {
                return _hour;
            }

            set
            {
                _hour = value;
                OnPropertyChanged("Hour");
            }
        }

        public string Temperature
        {
            get
            {
                return _temperature;
            }

            set
            {
                _temperature = value;
                OnPropertyChanged("Temperature");
            }
        }

        public string TypeOfDayImagePath
        {
            get
            {
                return _typeOfDayImagePath;
            }

            set
            {
                _typeOfDayImagePath = value;
                OnPropertyChanged("TypeOfDayImagePath");
            }
        }

        public string TypeOfDay
        {
            get
            {
                return _typeOfDay;
            }

            set
            {
                _typeOfDay = value;
                OnPropertyChanged("TypeOfDay");
            }
        }

        public HourWeather()
        {
            //Hour = "16:00";
            //TypeOfDayImagePath = "pack://application:,,,/Images/cloudy.png";
            //TypeOfDay = "Cloudy";
        }
    }
}
