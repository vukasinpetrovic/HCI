using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPWeather.Models;
using WPWeather.Other;

namespace WPWeather.ViewModels
{
    public class WeatherViewModel : Data
    {
        private DayViewModel _selectedDayViewModel { get; set; }
        private DayViewModel[] _dayViewModels { get; set; }
        private HourlyViewModel _selectedHourlyViewModel { get; set; }

        public DayViewModel[] DayViewModels
        {
            get
            {
                return _dayViewModels;
            }

            set
            {
                _dayViewModels = value;
                OnPropertyChanged("DayViewModels");
            }
        }

        public HourlyViewModel SelectedHourlyViewModel
        {
            get
            {
                return _selectedHourlyViewModel;
            }

            set
            {
                _selectedHourlyViewModel = value;
                OnPropertyChanged("SelectedHourlyViewModel");
            }
        }

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

        public RelayCommand<DayViewModel> ClickOnDay { get; set; }

        public WeatherViewModel()
        {
            DayViewModels = new DayViewModel[_numberOfDays];

            //for (int i = 0; i < _numberOfDays; ++i)
            //{
            //    DayViewModels[i] = new DayViewModel();
            //}

            SelectedDayViewModel = new DayViewModel();
            SelectedHourlyViewModel = new HourlyViewModel();

            ClickOnDay = new RelayCommand<DayViewModel>(setCurrentDay);
        }

        private void setCurrentDay(DayViewModel dw)
        {
            SelectedDayViewModel = new DayViewModel(dw.DayOfTheWeek, dw.TypeOfDayImagePath, dw.Temperature.Substring(4, dw.Temperature.Length - 5), dw.TypeOfDay, dw.date);

            MainWindowViewModel._wvm.SelectedHourlyViewModel.HourlyWeather.Clear();
            for (int i = 0; i < MainWindowViewModel.weatherData.list.Count; i++)
            {
                WeatherData wd = MainWindowViewModel.weatherData.list[i];
                DateTime dt = MainWindowViewModel.UnixTimeStampToDateTime(wd.dt);
                if (dw.date.ToString("yyyy-MM-dd").Equals(dt.ToString("yyyy-MM-dd")))
                {
                    HourWeather hw = new HourWeather();
                    hw.Hour = dt.ToString("HH:mm");
                    hw.Temperature = wd.main.temp.ToString() + " °C";
                    hw.TypeOfDay = wd.weather[0].description;
                    hw.TypeOfDayImagePath = "http://openweathermap.org/img/w/" + wd.weather[0].icon + ".png";
                    MainWindowViewModel._wvm.SelectedHourlyViewModel.HourlyWeather.Add(hw);
                }
            }
        }

        private int _numberOfDays = 5;
    }
}
