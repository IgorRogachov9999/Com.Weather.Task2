namespace Com.Weather.Task2.Domain.Services.Dto
{
    public class CountryWeatherDto
    {
        public string Name { get; set; }

        public IEnumerable<CityWeatherDto> Cities { get; set; } = Enumerable.Empty<CityWeatherDto>();
    }
}
