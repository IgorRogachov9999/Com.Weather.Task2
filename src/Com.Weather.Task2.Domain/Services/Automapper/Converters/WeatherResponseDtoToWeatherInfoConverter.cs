using AutoMapper;
using Com.Weather.Task2.Domain.Data.Entities;
using Com.Weather.Task2.Domain.Services.Dto.Client;

namespace Com.Weather.Task2.Domain.Services.Automapper.Converters
{
    public class WeatherResponseDtoToWeatherInfoConverter : ITypeConverter<WeatherResponseDto, IEnumerable<WeatherInfo>>
    {
        public IEnumerable<WeatherInfo> Convert(WeatherResponseDto source, IEnumerable<WeatherInfo> destination, ResolutionContext context)
        {
            var dateTime = DateTime.UtcNow;

            destination = source.List
                .Select(x => new WeatherInfo()
                {
                    Id = x.Id,
                    City = x.Name,
                    Country = x.Sys.Country,
                    MaxValue = x.Main.Temp_Max,
                    MinValue = x.Main.Temp_Min,
                    Timestamp = dateTime
                })
                .ToArray();

            return destination;
        }
    }
}
