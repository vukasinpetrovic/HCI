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
        public City City { get; set; }
        public bool Active { get; set; }
        public RelayCommand CmdDeleteBookmark { get; set; }

        public Bookmark(City city)
        {
            Active = true;
            City = city;
            CmdDeleteBookmark = new RelayCommand(DeleteBookmark);
        }

        private void DeleteBookmark()
        {
            Active = false;
            OnPropertyChanged("Active");
        }
    }
}
