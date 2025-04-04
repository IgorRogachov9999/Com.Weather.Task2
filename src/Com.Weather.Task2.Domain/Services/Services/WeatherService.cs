using AutoMapper;
using Com.Weather.Task2.Domain.Data.UnitOfWork.Contracts;
using Com.Weather.Task2.Domain.Services.Dto;
using Com.Weather.Task2.Domain.Services.Exceptions;
using Com.Weather.Task2.Domain.Services.Extensions;
using Com.Weather.Task2.Domain.Services.Services.Contracts;

namespace Com.Weather.Task2.Domain.Services.Services
{
    public class WeatherService : IWeatherService
    {
        private readonly IWeatherUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public WeatherService(
            IWeatherUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CountryWeatherDto>> GetAllAsync(CancellationToken ct)
        {
            await _unitOfWork.OpenConnectionAsync(ct);
            var weatherInfo = await _unitOfWork.WeatherRepository.GetAllAsync(ct);

            if (weatherInfo.IsNullOrEmpty())
            {
                throw new EntityNotFoundException("No weather data was found.");
            }

            var countryWeather = _mapper.Map<IEnumerable<CountryWeatherDto>>(weatherInfo);

            return countryWeather;
        }
    }
}
