using Com.Weather.Task2.Domain.Data.Factories.Contracts;
using Com.Weather.Task2.Domain.Data.Options;
using Microsoft.Extensions.Options;
using Npgsql;

namespace Com.Weather.Task2.Domain.Data.Factories
{
    public class NpgsqlConnectionFactory : IConnectionFactory
    {
        private readonly ConnectionStringsOptions _options;

        public NpgsqlConnectionFactory(IOptionsMonitor<ConnectionStringsOptions> connectionStringsOptions)
        {
            _options = connectionStringsOptions.CurrentValue;
        }

        public async Task<NpgsqlConnection> OpenConnectionAsync(CancellationToken ct = default)
        {
            var connection = new NpgsqlConnection(_options.DatabaseConnectionString);
            await connection.OpenAsync(ct);

            return connection;
        }
    }
}
