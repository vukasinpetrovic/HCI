using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPWeather.Other;

namespace WPWeather.ViewModels
{
    public class WeatherViewModel : Data
    {
        public DayViewModel[] DayViewModels { get; set; }
        public HourlyViewModel SelectedHourlyViewModel { get; set; }

        private DayViewModel _selectedDayViewModel { get; set; }
        public DayViewModel SelectedDayViewModel
        {
            get
            {
                return _selectedDayViewModel;
            }

            set
            {
                _selectedDayViewModel = value;
                OnPropertyChanged("SelectedDayViewModel");
            }
        }

        public WeatherViewModel()
        {
            //DayViewModels = new DayViewModel[_numberOfDays];

            //for (int i = 0; i < _numberOfDays; ++i)
            //{
            //    DayViewModels[i] = new DayViewModel();
            //}

            //SelectedDayViewModel = new DayViewModel();
            //SelectedHourlyViewModel = new HourlyViewModel();
        }

        private int _numberOfDays = 5;
    }
}
