using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPWeather.Other;

namespace WPWeather.ViewModels
{
    public class DayViewModel : Data
    {
        private string _dayOfTheWeek { get; set; }
        private string _typeOfDayImagePath { get; set; }
        private string _temperature { get; set; }
        private string _typeOfDay { get; set; }

        public DateTime date { get; set; }

        public string DayOfTheWeek {
            get
            {
                return _dayOfTheWeek;
            }

            set
            {
                _dayOfTheWeek = value;
                OnPropertyChanged("DayOfTheWeek");
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

        public DayViewModel()
        {
            //DayOfTheWeek = "Monday";
            //TypeOfDayImagePath = "pack://application:,,,/Images/cloudy.png";
            //Temperature = "16 C";
            //TypeOfDay = "Cloudy";
        }
    }
}
