using AutoMapper;
using Com.Weather.Task2.Domain.Data.Entities;
using Com.Weather.Task2.Domain.Data.UnitOfWork.Contracts;
using Com.Weather.Task2.Domain.Services.Exceptions;
using Com.Weather.Task2.Domain.Services.Extensions;
using Com.Weather.Task2.Domain.Services.Services.Contracts;

namespace Com.Weather.Task2.Domain.Services.Services
{
    public class WeatherPollerService : IWeatherPollerService
    {
        private readonly IWeatherClientService _client;
        private readonly IWeatherUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public WeatherPollerService(
            IWeatherClientService client,
            IWeatherUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _client = client;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task PollWeatherAsync(CancellationToken ct)
        {
            var cityWeather = await _client.GetWeatherDataAsync(ct);

            if (cityWeather == null || cityWeather.List.IsNullOrEmpty())
            {
                throw new InvalidPollingException("An exception has occurred during weather polling.");
            }

            var weatherInfo = _mapper.Map<WeatherInfo[]>(cityWeather);

            await _unitOfWork.OpenConnectionAsync(ct);
            await _unitOfWork.WeatherRepository.UpsertAsync(weatherInfo, ct);
        }
    }
}
