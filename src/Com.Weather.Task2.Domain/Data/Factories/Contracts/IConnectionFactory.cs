using Npgsql;

namespace Com.Weather.Task2.Domain.Data.Factories.Contracts
{
    public interface IConnectionFactory
    {
        Task<NpgsqlConnection> OpenConnectionAsync(CancellationToken ct = default);
    }
}
