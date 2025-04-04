namespace Com.Weather.Task2.Domain.Services.Dto
{
    public class CityWeatherDto
    {
        public string Name { get; set; }

        public decimal MinValue { get; set; }

        public decimal MaxValue { get; set; }

        public DateTime Timestamp { get; set; }
    }
}
