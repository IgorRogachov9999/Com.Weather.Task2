using Com.Weather.Task2.Domain.Data.Entities;

namespace Com.Weather.Task2.Domain.Data.Repositories.Contracts
{
    public interface IWeatherRepository
    {
        Task<IEnumerable<WeatherInfo>> GetAllAsync(CancellationToken ct);

        Task UpsertAsync(WeatherInfo[] weatherInfo, CancellationToken ct);
    }
}
