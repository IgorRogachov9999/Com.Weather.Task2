using Com.Weather.Task2.Api.BackgroundJobs;
using Com.Weather.Task2.Domain.Data.Extensions;
using Com.Weather.Task2.Domain.Services.Extensions;
using Quartz;

namespace Com.Weather.Task2.Api.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDataLayer(configuration);
            services.AddServicesLayer(configuration);
            services.AddBackgroundJobs(configuration);

            return services;
        }

        private static IServiceCollection AddBackgroundJobs(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddQuartz(x =>
            {
                var jobKey = new JobKey(Guid.NewGuid().ToString());
                x.AddJob<WeatherPollingJob>(jobKey);
                x.AddTrigger(t => t
                    .ForJob(jobKey)
                    .WithIdentity(Guid.NewGuid().ToString())
                    .StartAt(DateBuilder.EvenMinuteDate(null))
                    .WithSimpleSchedule(q => q.WithIntervalInMinutes(1).RepeatForever()));
            });

            services.AddQuartzHostedService(x => x.WaitForJobsToComplete = true);

            return services;
        }
    }
}
