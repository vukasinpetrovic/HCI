using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPWeather.Other;

namespace WPWeather.Models
{
    public class Bookmark : Data
    {
        public string CityName { get; set; }
        public bool Active { get; set; }
        public RelayCommand CmdDeleteBookmark { get; set; }

        public Bookmark(string cityName)
        {
            Active = true;
            CityName = cityName;
            CmdDeleteBookmark = new RelayCommand(DeleteBookmark);
        }

        private void DeleteBookmark()
        {
            Active = false;
            OnPropertyChanged("Active");
        }
    }
}
