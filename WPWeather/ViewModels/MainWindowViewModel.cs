using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Device.Location;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WPWeather.Models;
using WPWeather.Other;

namespace WPWeather.ViewModels
{
    public class MainWindowViewModel : Data
    {
        public static WeatherDataWrapper weatherData;
        public static double? my_location_lon = null;
        public static double? my_location_lat = null;

        public object Content
        {
            get { return _content; }
            set
            {
                SetField(ref _content, value, "Content");
            }
        }

        public ObservableCollection<City> AllCities { get; set; } = new ObservableCollection<City>();

        public City SelectedCity
        {
            get
            {
                return _selectedCity;
            }

            set
            {
                _selectedCity = value;
                OnPropertyChanged("SelectedCity");
                CheckBookmarkIcon();
            }
        }

        private Bookmark _selectedBookmark { get; set; }
        public Bookmark SelectedBookmark {
            get
            {
                return _selectedBookmark;
            }

            set {
                _selectedBookmark = value;
                OnListItemClick();
            }
        }

        public RelayCommand CmdChangedCity { get; set; }

        public RelayCommand SelectedItemChangedCommand { get; set; }

        public BindingList<Bookmark> Bookmarks { get; set; } = new BindingList<Bookmark>();

        public RelayCommand CmdBookmark { get; set; }

        public RelayCommand CmdLocation { get; set; }

        public string BookmarkIcon
        {
            get
            {
                return _bookmarkIcon;
            }

            set
            {
                _bookmarkIcon = value;
                OnPropertyChanged("BookmarkIcon");
            }
        }

        public MainWindowViewModel()
        {
            Content = _hvm;

            SelectedCity = null;

            CmdChangedCity = new RelayCommand(ChangedCity);

            SelectedItemChangedCommand = new RelayCommand(OnListItemClick);

            Bookmarks.ListChanged += BookmarksChanged;
            CmdBookmark = new RelayCommand(Bookmark);
            CmdLocation = new RelayCommand(LoadWeatherForMyLocation);

            using (StreamReader file = File.OpenText(Directory.GetCurrentDirectory()  + "/city.list.json"))
            {
                JsonSerializer serializer = new JsonSerializer();
                AllCities = (ObservableCollection<City>)serializer.Deserialize(file, typeof(ObservableCollection<City>));
            }

            GeoCoordinateWatcher watcher = new GeoCoordinateWatcher();
            watcher.PositionChanged += watcher_PositionChanged;
            watcher.Start();
        }

        private void LoadWeatherForMyLocation()
        {
            if (my_location_lon != null && my_location_lat != null)
            {
                weatherData = WeatherService.get5DayForecastByCityLocation(my_location_lat.GetValueOrDefault(), my_location_lon.GetValueOrDefault());
                for (int i = 0; i < AllCities.Count(); i++)
                {
                    if (AllCities[i].id == weatherData.city.id)
                    {
                        SelectedCity = AllCities[i];
                        ChangedCity();
                        break;
                    }
                }
            } 
            else
            {
                MessageBox.Show("Nije moguce pronaci vasu lokaciju, nije do nas, windows glupi...", "Obaveštenje", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void watcher_PositionChanged(object sender, GeoPositionChangedEventArgs<GeoCoordinate> e)
        {
            my_location_lat = e.Position.Location.Latitude;
            my_location_lon = e.Position.Location.Longitude;
        }

        private void OnListItemClick()
        {
            SelectedCity = SelectedBookmark.City;

            ChangedCity();
        }

        public static DateTime UnixTimeStampToDateTime(double unixTimeStamp)
        {
            // Unix timestamp is seconds past epoch
            System.DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
            dtDateTime = dtDateTime.AddSeconds(unixTimeStamp).ToLocalTime();
            return dtDateTime;
        }

        private void ChangedCity()
        {
            if (SelectedCity != null)
            {
                weatherData = WeatherService.get5DayForecastByCityID(SelectedCity.id.ToString());

                DateTime today = DateTime.Now;

                //DayViewModel dw = new DayViewModel();
                _wvm.SelectedHourlyViewModel = new HourlyViewModel();
                _wvm.SelectedDayViewModel = new DayViewModel();
                _wvm.SelectedDayViewModel.Temperature = weatherData.list[0].main.temp.ToString() + " °C";
                _wvm.SelectedDayViewModel.DayOfTheWeek = new DateTime(weatherData.list[0].dt).AddDays(1).DayOfWeek.ToString();
                _wvm.SelectedDayViewModel.TypeOfDay = weatherData.list[0].weather[0].description;
                _wvm.SelectedDayViewModel.TypeOfDayImagePath = "http://openweathermap.org/img/w/" + weatherData.list[0].weather[0].icon + ".png";

                for (int i = 0; i < weatherData.list.Count; i++)
                {
                    WeatherData wd = weatherData.list[i];
                    DateTime dt = UnixTimeStampToDateTime(wd.dt);
                    if (today.ToString("yyyy-MM-dd").Equals(dt.ToString("yyyy-MM-dd")))
                    {
                        HourWeather hw = new HourWeather();
                        hw.Hour = dt.ToString("HH:mm");
                        hw.Temperature = wd.main.temp.ToString() + " °C";
                        hw.TypeOfDay = wd.weather[0].description;
                        hw.TypeOfDayImagePath = "http://openweathermap.org/img/w/" + wd.weather[0].icon + ".png";
                        _wvm.SelectedHourlyViewModel.HourlyWeather.Add(hw);
                    }
                }


                /* -------------- DAY 1 -------------- */
                double temp = 0;
                int tempCount = 0;

                DayViewModel day1 = new DayViewModel();
                day1.date = DateTime.Now;
                day1.DayOfTheWeek = day1.date.DayOfWeek.ToString();
                for (int i = 0; i < weatherData.list.Count; i++)
                {
                    WeatherData wd = weatherData.list[i];
                    DateTime dt = UnixTimeStampToDateTime(wd.dt);
                    if (day1.date.ToString("yyyy-MM-dd").Equals(dt.ToString("yyyy-MM-dd")))
                    {
                        temp += wd.main.temp;
                        tempCount += 1;
                    }
                    else if (day1.date.CompareTo(dt) == -1)
                    {
                        day1.TypeOfDay = weatherData.list[i - (tempCount / 2)].weather[0].description;
                        day1.TypeOfDayImagePath = "http://openweathermap.org/img/w/" + weatherData.list[i - (tempCount / 2)].weather[0].icon + ".png";
                        break;
                    }
                }
                day1.Temperature = String.Format("avg. {0:00.0} °C", tempCount == 0 ? weatherData.list[0].main.temp : (temp / tempCount));


                /* -------------- DAY 2 -------------- */
                temp = 0;
                tempCount = 0;

                DayViewModel day2 = new DayViewModel();
                day2.date = DateTime.Now.AddDays(1);
                day2.DayOfTheWeek = day2.date.DayOfWeek.ToString();
                for (int i = 0; i < weatherData.list.Count; i++)
                {
                    WeatherData wd = weatherData.list[i];
                    DateTime dt = UnixTimeStampToDateTime(wd.dt);
                    if (day2.date.ToString("yyyy-MM-dd").Equals(dt.ToString("yyyy-MM-dd")))
                    {
                        temp += wd.main.temp;
                        tempCount += 1;
                    }
                    else if (day2.date.CompareTo(dt) == -1)
                    {
                        day2.TypeOfDay = weatherData.list[i - (tempCount / 2)].weather[0].description;
                        day2.TypeOfDayImagePath = "http://openweathermap.org/img/w/" + weatherData.list[i - (tempCount / 2)].weather[0].icon + ".png";
                        break;
                    }
                }
                day2.Temperature = String.Format("avg. {0:00.0} °C", (temp / tempCount));

                /* -------------- DAY 3 -------------- */
                temp = 0;
                tempCount = 0;

                DayViewModel day3 = new DayViewModel();
                day3.date = DateTime.Now.AddDays(2);
                day3.DayOfTheWeek = day3.date.DayOfWeek.ToString();
                for (int i = 0; i < weatherData.list.Count; i++)
                {
                    WeatherData wd = weatherData.list[i];
                    DateTime dt = UnixTimeStampToDateTime(wd.dt);
                    if (day3.date.ToString("yyyy-MM-dd").Equals(dt.ToString("yyyy-MM-dd")))
                    {
                        temp += wd.main.temp;
                        tempCount += 1;
                    }
                    else if (day3.date.CompareTo(dt) == -1)
                    {
                        day3.TypeOfDay = weatherData.list[i - (tempCount / 2)].weather[0].description;
                        day3.TypeOfDayImagePath = "http://openweathermap.org/img/w/" + weatherData.list[i - (tempCount / 2)].weather[0].icon + ".png";
                        break;
                    }
                }
                day3.Temperature = String.Format("avg. {0:00.0} °C", (temp / tempCount));

                /* -------------- DAY 4 -------------- */
                temp = 0;
                tempCount = 0;

                DayViewModel day4 = new DayViewModel();
                day4.date = DateTime.Now.AddDays(3);
                day4.DayOfTheWeek = day4.date.DayOfWeek.ToString();
                for (int i = 0; i < weatherData.list.Count; i++)
                {
                    WeatherData wd = weatherData.list[i];
                    DateTime dt = UnixTimeStampToDateTime(wd.dt);
                    if (day4.date.ToString("yyyy-MM-dd").Equals(dt.ToString("yyyy-MM-dd")))
                    {
                        temp += wd.main.temp;
                        tempCount += 1;
                    }
                    else if (day4.date.CompareTo(dt) == -1)
                    {
                        day4.TypeOfDay = weatherData.list[i - (tempCount / 2)].weather[0].description;
                        day4.TypeOfDayImagePath = "http://openweathermap.org/img/w/" + weatherData.list[i - (tempCount / 2)].weather[0].icon + ".png";
                        break;
                    }
                }
                day4.Temperature = String.Format("avg. {0:00.0} °C", (temp / tempCount));

                /* -------------- DAY 5 -------------- */
                temp = 0;
                tempCount = 0;

                DayViewModel day5 = new DayViewModel();
                day5.date = DateTime.Now.AddDays(4);
                day5.DayOfTheWeek = day5.date.DayOfWeek.ToString();
                for (int i = 0; i < weatherData.list.Count; i++)
                {
                    WeatherData wd = weatherData.list[i];
                    DateTime dt = UnixTimeStampToDateTime(wd.dt);
                    if (day5.date.ToString("yyyy-MM-dd").Equals(dt.ToString("yyyy-MM-dd")))
                    {
                        temp += wd.main.temp;
                        tempCount += 1;
                    }
                    else if (day5.date.CompareTo(dt) == -1)
                    {
                        day5.TypeOfDay = weatherData.list[i - (tempCount / 2)].weather[0].description;
                        day5.TypeOfDayImagePath = "http://openweathermap.org/img/w/" + weatherData.list[i - (tempCount / 2)].weather[0].icon + ".png";
                        break;
                    }
                }
                day5.Temperature = String.Format("avg. {0:00.0} °C", (temp / tempCount));

                _wvm.DayViewModels = new DayViewModel[5] { day1, day2, day3, day4, day5 };

                Content = _wvm;
                //_wvm.SelectedDayViewModel = dw;
            }
            else
            {
                Content = _hvm;
            }
        }

        private void Bookmark()
        {
            if (SelectedCity != null)
            {
                bool removed = false;
                foreach (Bookmark b in Bookmarks)
                {
                    if (b.City.id == SelectedCity.id)
                    {
                        Bookmarks.Remove(b);
                        OnPropertyChanged("Bookmarks");
                        removed = true;
                        CheckBookmarkIcon();
                        break;
                    }
                }

                if (!removed)
                {
                    Bookmarks.Add(new Bookmark(SelectedCity));
                    CheckBookmarkIcon();
                    OnPropertyChanged("Bookmarks");
                }
            }
        }

        private void CheckBookmarkIcon()
        {
            bool bookmarked = false;
            foreach (Bookmark b in Bookmarks)
            {
                if (b.City.id == _selectedCity.id)
                {
                    BookmarkIcon = "\u2605";
                    bookmarked = true;
                    break;
                }
            }

            if (!bookmarked) BookmarkIcon = "\u2729";
        }

        private void BookmarksChanged(object sender, ListChangedEventArgs e)
        {
            for (int i = 0; i < Bookmarks.Count; ++i)
            {
                if (!Bookmarks[i].Active)
                {
                    Bookmarks.RemoveAt(i);
                    OnPropertyChanged("Bookmarks");
                    CheckBookmarkIcon();
                    return;
                }
            }
        }

        private City _selectedCity = null;
        private string _bookmarkIcon = "";

        private object _content;
        public static HomepageViewModel _hvm = App.Current.Resources["HomepageViewModel"] as HomepageViewModel;
        public static WeatherViewModel _wvm = App.Current.Resources["WeatherViewModel"] as WeatherViewModel;
    }
}
