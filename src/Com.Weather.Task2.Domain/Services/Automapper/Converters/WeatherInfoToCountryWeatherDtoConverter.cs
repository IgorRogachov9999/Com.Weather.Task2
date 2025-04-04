using AutoMapper;
using Com.Weather.Task2.Domain.Data.Entities;
using Com.Weather.Task2.Domain.Services.Dto;

namespace Com.Weather.Task2.Domain.Services.Automapper.Converters
{
    public class WeatherInfoToCountryWeatherDtoConverter : ITypeConverter<IEnumerable<WeatherInfo>, IEnumerable<CountryWeatherDto>>
    {
        public IEnumerable<CountryWeatherDto> Convert(IEnumerable<WeatherInfo> source, IEnumerable<CountryWeatherDto> destination, ResolutionContext context)
        {
            destination = source
                .GroupBy(x => x.Country)
                .Select(x => new CountryWeatherDto()
                {
                    Name = x.Key,
                    Cities = x
                        .OrderBy(c => c.City)
                        .Select(c => new CityWeatherDto()
                        {
                            Name = c.City,
                            MaxValue = c.MaxValue,
                            MinValue = c.MinValue,
                            Timestamp = c.Timestamp
                        })
                })
                .ToArray();

            return destination;
        }
    }
}
