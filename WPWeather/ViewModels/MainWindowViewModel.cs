using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
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

        public ObservableCollection<string> Cities { get; set; } = new ObservableCollection<string>()
        {
            "Novi Sad, Serbia",
            "Belgrade, Serbia",
            "Montreal, Canada",
            "Zagreb, Croatia",
            "London, UK"
        };

        public string SelectedCity
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

        public BindingList<Bookmark> Bookmarks { get; } = new BindingList<Bookmark>()
        {
            new Bookmark("Novi Sad, Serbia"),
            new Bookmark("Belgrade, Serbia"),
            new Bookmark("Montreal, Canada"),
            new Bookmark("Zagreb, Croatia"),
            new Bookmark("London, UK")
        };

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

            SelectedCity = "";


            CmdChangedCity = new RelayCommand(ChangedCity);

            Bookmarks.ListChanged += BookmarksChanged;
            CmdBookmark = new RelayCommand(Bookmark);
        }

        private void ChangedCity()
        {
            if (SelectedCity != null && SelectedCity != string.Empty)
            {
                Content = _wvm;
            }
            else
            {
                Content = _hvm;
            }
        }

        private void Bookmark()
        {
            if (SelectedCity != null && SelectedCity != string.Empty)
            {
                bool removed = false;
                foreach (Bookmark b in Bookmarks)
                {
                    if (b.CityName.Equals(SelectedCity))
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
                if (b.CityName.Equals(_selectedCity))
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
                    --i;
                }
            }
        }

        private string _selectedCity = "";
        private string _bookmarkIcon = "";

        private object _content;
        private HomepageViewModel _hvm = new HomepageViewModel();
        private WeatherViewModel _wvm = new WeatherViewModel();
    }
}
