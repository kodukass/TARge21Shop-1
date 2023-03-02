using System.Text.Json.Serialization;

namespace TARge21Shop.Core.Dto.WeatherDtos
{
    public class DailyForecastsDto
    {
        //[JsonPropertyName("EffectiveDate")]
        //public DateTime Date { get; set; }
        //[JsonPropertyName("EffectiveEpochDate")]
        //public int EpochDate { get; set; }
        //[JsonPropertyName("Severity")]
        //public int Severity { get; set; }
        public Temperature Temperature { get; set; }
        //[JsonPropertyName("Text")]
        //public string Text { get; set; }
        //[JsonPropertyName("Category")]
        //public string Category { get; set; }
        public Day Day { get; set; }
        public Night Night { get; set; }
        public List<string> Sources { get; set; }
        //[JsonPropertyName("EffectiveDate")]
        //public string MobileLink { get; set; }
        //[JsonPropertyName("EffectiveDate")]
        //public string Link { get; set; }
    }

    public class Temperature
    {
        public Minimum Minimum { get; set; }
        public Maximum Maximum { get; set; }
    }

    public class Day
    {
        [JsonPropertyName("Icon")]
        public int Icon { get; set; }
        [JsonPropertyName("IconPhrase")]
        public string IconPhrase { get; set; }
        [JsonPropertyName("HasPercipitation")]
        public bool HasPrecipitation { get; set; }
        [JsonPropertyName("PercipitationType")]
        public string PrecipitationType { get; set; }
        [JsonPropertyName("PercipitationIntencity")]
        public string PrecipitationIntensity { get; set; }
    }

    public class Night
    {
        [JsonPropertyName("Icon")]
        public int Icon { get; set; }
        [JsonPropertyName("IconPhrase")]
        public string IconPhrase { get; set; }
        [JsonPropertyName("HasPercipitation")]
        public bool HasPrecipitation { get; set; }
        [JsonPropertyName("PercipitationType")]
        public string PrecipitationType { get; set; }
        [JsonPropertyName("PercipitationIntencity")]
        public string PrecipitationIntensity { get; set; }
    }

    public class Maximum
    {
        [JsonPropertyName("Value")]
        public double Value { get; set; }
        [JsonPropertyName("Unit")]
        public string Unit { get; set; }
        [JsonPropertyName("UnitType")]
        public int UnitType { get; set; }
    }

    public class Minimum
    {
        [JsonPropertyName("Value")]
        public double Value { get; set; }
        [JsonPropertyName("Unit")]
        public string Unit { get; set; }
        [JsonPropertyName("UnitType")]
        public int UnitType { get; set; }
    }
}