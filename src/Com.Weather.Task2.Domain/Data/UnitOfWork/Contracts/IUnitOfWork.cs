namespace Com.Weather.Task2.Domain.Data.UnitOfWork.Contracts
{
    public interface IUnitOfWork : IDisposable, IAsyncDisposable
    {
        Task OpenConnectionAsync(CancellationToken ct = default);

        Task BeginTransactionAsync(CancellationToken ct = default);

        Task CommitTransactionAsync(CancellationToken ct = default);

        Task RollbackTransactionAsync(CancellationToken ct = default);
    }
}
