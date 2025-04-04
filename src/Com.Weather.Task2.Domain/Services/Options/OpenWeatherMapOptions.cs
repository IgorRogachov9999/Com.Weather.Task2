namespace Com.Weather.Task2.Domain.Services.Options
{
    public class OpenWeatherMapOptions
    {
        public const string SectionName = "OpenWeatherMap";

        public string ApiKey { get; set; }

        public string BaseUrl { get; set; }

        public string CityIds { get; set; }
    }
}
