using Com.Weather.Task2.Domain.Data.Factories.Contracts;
using Com.Weather.Task2.Domain.Data.UnitOfWork.Contracts;
using Npgsql;
using System.Data.Common;

namespace Com.Weather.Task2.Domain.Data.UnitOfWork
{
    public class BaseUnitOfWork : IUnitOfWork
    {
        private readonly IConnectionFactory _connectionFactory;

        protected NpgsqlConnection? DbConnection { get; private set; }

        protected DbTransaction? DbTransaction { get; private set; }

        protected BaseUnitOfWork(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task BeginTransactionAsync(CancellationToken ct = default)
        {
            if (DbConnection is null)
            {
                throw new InvalidOperationException($"Connection is closed or does not exist.");
            }

            DbTransaction = await DbConnection.BeginTransactionAsync(ct);
        }

        public async Task CommitTransactionAsync(CancellationToken ct = default)
        {
            try
            {
                await DbTransaction!.CommitAsync(ct);
            }
            catch
            {
                await DbTransaction!.RollbackAsync(ct);
                throw;
            }
            finally
            {
                await DisposeAsync();
            }
        }

        public void Dispose()
        {
            if (DbTransaction is not null)
            {
                DbTransaction.Dispose();
                DbTransaction = null;
            }

            if (DbConnection is not null)
            {
                DbConnection.Dispose();
                DbConnection = null;
            }
        }

        public async ValueTask DisposeAsync()
        {
            if (DbTransaction is not null)
            {
                await DbTransaction.DisposeAsync();
                DbTransaction = null;
            }

            if (DbConnection is not null)
            {
                await DbConnection.DisposeAsync();
                DbConnection = null;
            }
        }

        public async Task OpenConnectionAsync(CancellationToken ct = default)
        {
            if (DbConnection == null)
            {
                DbConnection = await _connectionFactory.OpenConnectionAsync(ct);
            }
        }

        public async Task RollbackTransactionAsync(CancellationToken ct = default)
        {
            try
            {
                await DbTransaction!.RollbackAsync(ct);
            }
            finally
            {
                await DisposeAsync();
            }
        }
    }
}
