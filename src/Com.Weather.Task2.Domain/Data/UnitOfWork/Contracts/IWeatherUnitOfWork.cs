using Com.Weather.Task2.Domain.Data.Repositories.Contracts;

namespace Com.Weather.Task2.Domain.Data.UnitOfWork.Contracts
{
    public interface IWeatherUnitOfWork : IUnitOfWork
    {
        IWeatherRepository WeatherRepository { get; }
    }
}
