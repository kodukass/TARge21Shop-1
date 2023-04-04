namespace TARge21Shop.Models.Weather
{
    public class OpenWeatherViewModel
    {
        public Coord Coords { get; set; }
        public List<Weather> Weathers { get; set; }
        public Main Mains { get; set; }
        public Wind Winds { get; set; }
        public string Name { get; set; }

        public class Coord
        {
            public double Lon { get; set; }
            public double Lat { get; set; }
        }

        public class Main
        {
            public double Temp { get; set; }
            public double Feels_like { get; set; }
            public int Pressure { get; set; }
            public int Humidity { get; set; }
        }

        public class Weather
        {
            public string Main { get; set; }
            public string Description { get; set; }
        }

        public class Wind
        {
            public double Speed { get; set; }
        }
    }
}
