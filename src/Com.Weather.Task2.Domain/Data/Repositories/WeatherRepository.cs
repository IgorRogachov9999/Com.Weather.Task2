using Com.Weather.Task2.Domain.Data.Entities;
using Com.Weather.Task2.Domain.Data.Extensions;
using Com.Weather.Task2.Domain.Data.Repositories.Contracts;
using Dapper;
using Npgsql;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Common;
using System.Reflection;

namespace Com.Weather.Task2.Domain.Data.Repositories
{
    public class WeatherRepository : IWeatherRepository
    {
        private readonly NpgsqlConnection _connection;
        private readonly DbTransaction _transaction;

        public WeatherRepository(NpgsqlConnection connection, DbTransaction transaction)
        {
            _connection = connection;
            _transaction = transaction;
        }

        public Task<IEnumerable<WeatherInfo>> GetAllAsync(CancellationToken ct)
        {
            var tableName = GetTableName<WeatherInfo>();
            var query = $"SELECT id, country, city, min_value, max_value, timestamp FROM {tableName}";
            var command = new CommandDefinition(query, transaction:  _transaction, cancellationToken: ct);

            return _connection.QueryAsync<WeatherInfo>(command);
        }

        public Task UpsertAsync(WeatherInfo[] weatherInfo, CancellationToken ct)
        {
            var tableName = GetTableName<WeatherInfo>();
            var query = $@"INSERT INTO {tableName} (id, country, city, min_value, max_value, timestamp)
                           VALUES (@Id, @Country, @City, @MinValue, @MaxValue, @Timestamp)
                           ON CONFLICT (id) DO UPDATE
                           SET max_value = @MaxValue,
                               min_value = @MinValue,
                               timestamp = @Timestamp";
            var command = new CommandDefinition(query, weatherInfo, transaction: _transaction, cancellationToken: ct);
            
            return _connection.ExecuteAsync(command);
        }

        private string GetTableName<T>()
        {
            var type = typeof(T);
            var tableAttribute = type.GetCustomAttribute<TableAttribute>();
            return tableAttribute?.Name ?? NameConverter.ToSnakeCase(type.Name);
        }
    }
}
