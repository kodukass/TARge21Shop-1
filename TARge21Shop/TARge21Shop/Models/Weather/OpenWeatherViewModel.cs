namespace TARge21Shop.Models.Weather
{
    public class OpenWeatherViewModel
    {
        //main
        public double temp { get; set; }
        public double feels_like { get; set; }
        public int pressure { get; set; }
        public int humidity { get; set; }

        //wind
        public double speed { get; set; }

        //weather
        public string main { get; set; } //condition
    }
}
