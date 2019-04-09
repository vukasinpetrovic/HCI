namespace WPWeather
{
    public class City
    {
        public int id { get; set; }

        public string name { get; set; }

        public string country { get; set; }

        public Coordinates coord { get; set; }

        public int population { get; set; }

        override
        public string ToString()
        {
            return this.name + ", " + this.country;
        }
    }
}
