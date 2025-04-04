using Com.Weather.Task2.Domain.Data.Factories.Contracts;
using Com.Weather.Task2.Domain.Data.Repositories;
using Com.Weather.Task2.Domain.Data.Repositories.Contracts;
using Com.Weather.Task2.Domain.Data.UnitOfWork.Contracts;

namespace Com.Weather.Task2.Domain.Data.UnitOfWork
{
    public class WeatherUnitOfWork : BaseUnitOfWork, IWeatherUnitOfWork
    {
        public WeatherUnitOfWork(IConnectionFactory connectionFactory) : base(connectionFactory)
        {
        }

        public IWeatherRepository WeatherRepository => new WeatherRepository(DbConnection, DbTransaction);
    }
}
