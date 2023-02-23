using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static TARge21Shop.Core.Dto.WeatherData.DailyForecastsDto;

namespace TARge21Shop.Core.Dto.WeatherData
{
    public class DailyForecastsDto
    {
        public object Date { get; set; }
        public object EpochDate { get; set; }
        public object Temperature { get; set; }

        public class DailyForecast
        {
            public DateTime Date { get; set; }
            public int EpochDate { get; set; }
            public Temperatures Temperature { get; set; }
            public DayNightCycles DayCycle { get; set; }
            public List<string> Sources { get; set; }
            public Temperatures Minimum { get; set; }
            public Temperatures Maximum { get; set; }
            public string MobileLink { get; set; }
            public string Link { get; set; }
        }

        public class DayNightCycles
        {
            public int Icon { get; set; }
            public string IconPhrase { get; set; }
            public bool HasPrecipitation { get; set; }
            public string PrecipitationType { get; set; }
            public string PrecipitationIntensity { get; set; }
        }

        public class Minimum
        {
            public double Value { get; set; }
            public string Unit { get; set; }
            public int UnitType { get; set; }
        }

        public class Temperatures
        {
            public Temperatures Minimum { get; set; }
            public Temperatures Maximum { get; set; }
        }
    }
}
