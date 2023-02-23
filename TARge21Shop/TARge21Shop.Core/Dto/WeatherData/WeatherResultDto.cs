using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static TARge21Shop.Core.Dto.WeatherData.DailyForecastsDto;

namespace TARge21Shop.Core.Dto.WeatherData
{
    public class WeatherResultDto
    {
        public DateTime EffectiveDate { get; set; }
        public DateTime Date { get; set; }
        public int EpochDate { get; set; }
        public Temperatures Temperature { get; set; }
        public DayNightCycles DayCycle { get; set; }
        public List<string> Sources { get; set; }
        public string MobileLink { get; set; }
        public string Link { get; set; }
        public int Icon { get; set; }
        public string IconPhrase { get; set; }
        public bool HasPrecipitation { get; set; }
        public string PrecipitationType { get; set; }
        public string PrecipitationIntensity { get; set; }
        public double Value { get; set; }
        public string Unit { get; set; }
        public int UnitType { get; set; }
        public Temperatures Minimum { get; set; }
        public Temperatures Maximum { get; set; }
        public int EffectiveEpochDate { get; set; }
        public int Severity { get; set; }
        public string Text { get; set; }
        public string Category { get; set; }
        public DateTime EndDate { get; set; }
        public int EndEpochDate { get; set; }
        public object DailyForecastsDay { get; set; }
        public object DailyForecastsEpochDate { get; set; }
        public object TempMinValue { get; set; }
        public object TempMinUnit { get; set; }
        public object TempMinUnitType { get; set; }
        public object TempMaxValue { get; set; }
        public object TempMaxUnit { get; set; }
        public object TempMaxUnitType { get; set; }
    }
}
