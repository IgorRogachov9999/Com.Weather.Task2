namespace Com.Weather.Task2.Domain.Services.Services.Contracts
{
    public interface IWeatherPollerService
    {
        Task PollWeatherAsync(CancellationToken ct);
    }
}
