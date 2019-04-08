using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPWeather.ViewModels
{
    public class WeatherViewModel
    {
        public DayViewModel[] DayViewModels { get; set; }
        public DayViewModel SelectedDayViewModel { get; set; }
        public HourlyViewModel SelectedHourlyViewModel { get; set; }

        public WeatherViewModel()
        {
            DayViewModels = new DayViewModel[_numberOfDays];

            for (int i = 0; i < _numberOfDays; ++i)
            {
                DayViewModels[i] = new DayViewModel();
            }

            SelectedDayViewModel = new DayViewModel();
            SelectedHourlyViewModel = new HourlyViewModel();
        }

        private int _numberOfDays = 5;
    }
}
