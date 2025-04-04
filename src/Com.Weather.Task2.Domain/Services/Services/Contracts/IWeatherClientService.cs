using Com.Weather.Task2.Domain.Services.Dto.Client;

namespace Com.Weather.Task2.Domain.Services.Services.Contracts
{
    public interface IWeatherClientService
    {
        Task<WeatherResponseDto> GetWeatherDataAsync(CancellationToken ct);
    }
}
