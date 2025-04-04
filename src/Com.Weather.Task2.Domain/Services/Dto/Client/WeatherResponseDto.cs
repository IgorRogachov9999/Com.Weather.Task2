namespace Com.Weather.Task2.Domain.Services.Dto.Client
{
    public class WeatherResponseDto
    {
        public int Cnt { get; set; }
        public IEnumerable<WeatherCityDto> List { get; set; }
    }
}
