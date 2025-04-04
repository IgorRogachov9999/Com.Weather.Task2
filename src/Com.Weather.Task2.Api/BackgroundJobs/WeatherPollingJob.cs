using Com.Weather.Task2.Domain.Services.Services.Contracts;
using Quartz;

namespace Com.Weather.Task2.Api.BackgroundJobs
{
    public class WeatherPollingJob : IJob
    {
        private readonly IWeatherPollerService _weatherPollerService;
        private readonly ILogger<WeatherPollingJob> _logger;

        public WeatherPollingJob(
            IWeatherPollerService weatherPollerService,
            ILoggerFactory loggerFactory)
        {
            _weatherPollerService = weatherPollerService;
            _logger = loggerFactory.CreateLogger<WeatherPollingJob>();
        }

        public async Task Execute(IJobExecutionContext context)
        {
            try
            {
                await _weatherPollerService.PollWeatherAsync(CancellationToken.None);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
            }
        }
    }
}
