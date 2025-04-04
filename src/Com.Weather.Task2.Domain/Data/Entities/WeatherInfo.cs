using System.ComponentModel.DataAnnotations.Schema;

namespace Com.Weather.Task2.Domain.Data.Entities
{
    [Table("weather.weather_info")]
    public class WeatherInfo
    {
        public int Id { get; set; }

        public string Country { get; set; }

        public string City { get; set; }

        public decimal MinValue { get; set; }

        public decimal MaxValue { get; set; }

        public DateTime Timestamp { get; set; }
    }
}
