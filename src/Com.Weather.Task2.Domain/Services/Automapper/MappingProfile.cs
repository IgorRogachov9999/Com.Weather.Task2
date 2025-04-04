using AutoMapper;
using Com.Weather.Task2.Domain.Data.Entities;
using Com.Weather.Task2.Domain.Services.Automapper.Converters;
using Com.Weather.Task2.Domain.Services.Dto;
using Com.Weather.Task2.Domain.Services.Dto.Client;

namespace Com.Weather.Task2.Domain.Services.Automapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<IEnumerable<WeatherInfo>, IEnumerable<CountryWeatherDto>>().ConvertUsing<WeatherInfoToCountryWeatherDtoConverter>();
            CreateMap<WeatherResponseDto, IEnumerable<WeatherInfo>>().ConvertUsing<WeatherResponseDtoToWeatherInfoConverter>();
        }
    }
}
