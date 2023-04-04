using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TARge21Shop.Core.Dto.WeatherData
{
    public class MainDto
    {
        //main
        [JsonPropertyName("temp")]
        public double temp { get; set; }
        [JsonPropertyName("feels_like")]
        public double feels_like { get; set; }
        [JsonPropertyName("pressure")]
        public int pressure { get; set; }
        [JsonPropertyName("humidity")]
        public int humidity { get; set; }

        //wind
        [JsonPropertyName("speed")]
        public double speed { get; set; }

        //weather
        [JsonPropertyName("main")]
        public string main { get; set; } //condition

        //name
        [JsonPropertyName("name")]
        public string name { get; set; }
    }
}
