using System.Text.Json.Serialization;

namespace Workspace.Shared
{
    public class WeatherForecast
    {
        public int id { get; set; }
        public DateTime Date { get; set; }


        [JsonIgnore]
        public int TemperatureC { get; set; }

        public string? Summary { get; set; }

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
    }
}