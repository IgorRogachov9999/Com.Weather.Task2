using Com.Weather.Task2.Domain.Services.Dto;

namespace Com.Weather.Task2.Domain.Services.Services.Contracts
{
    public interface IWeatherService
    {
        Task<IEnumerable<CountryWeatherDto>> GetAllAsync(CancellationToken ct);
    }
}
