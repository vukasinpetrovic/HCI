using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPWeather.Models;
using WPWeather.Other;

namespace WPWeather.ViewModels
{
    public class MainWindowViewModel : Data
    {
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
                CheckBookmarkIcon();
            }
        }

        public RelayCommand CmdChangedCity { get; set; }

        public BindingList<Bookmark> Bookmarks { get; set; } = new BindingList<Bookmark>();

        public RelayCommand CmdBookmark { get; set; }

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

            Bookmarks.ListChanged += BookmarksChanged;
            CmdBookmark = new RelayCommand(Bookmark);

            using (StreamReader file = File.OpenText(Directory.GetCurrentDirectory()  + "/city.list.json"))
            {
                JsonSerializer serializer = new JsonSerializer();
                AllCities = (ObservableCollection<City>)serializer.Deserialize(file, typeof(ObservableCollection<City>));
            }
        }

        private void ChangedCity()
        {
            if (SelectedCity != null)
            {
                WeatherDataWrapper weatherData = WeatherService.get5DayForecastByCityID(SelectedCity.id.ToString());

                DayViewModel dw = new DayViewModel();
                dw.Temperature = weatherData.list[0].main.temp.ToString();
                dw.DayOfTheWeek = new DateTime(weatherData.list[0].dt).DayOfWeek.ToString();
                dw.TypeOfDay = weatherData.list[0].weather[0].description;

                _wvm.SelectedDayViewModel = dw;
                Content = _wvm;
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
            bool removed = false;
            for (int i = 0; i < Bookmarks.Count; ++i)
            {
                if (!Bookmarks[i].Active)
                {
                    Bookmarks.ListChanged -= BookmarksChanged;
                    removed = true;
                    Bookmarks.RemoveAt(i);
                    --i;
                }
            }

            if (removed)
            {
                OnPropertyChanged("Bookmarks");
                CheckBookmarkIcon();
                Bookmarks.ListChanged += BookmarksChanged;
            }
        }

        private City _selectedCity = null;
        private string _bookmarkIcon = "";

        private object _content;
        private HomepageViewModel _hvm = new HomepageViewModel();
        private WeatherViewModel _wvm = new WeatherViewModel();
    }
}
