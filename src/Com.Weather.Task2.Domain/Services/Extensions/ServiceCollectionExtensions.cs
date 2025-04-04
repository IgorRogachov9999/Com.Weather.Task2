using Com.Weather.Task2.Domain.Services.Automapper;
using Com.Weather.Task2.Domain.Services.Options;
using Com.Weather.Task2.Domain.Services.Services;
using Com.Weather.Task2.Domain.Services.Services.Contracts;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Com.Weather.Task2.Domain.Services.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddServicesLayer(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<OpenWeatherMapOptions>(options =>
            {
                configuration.GetSection(OpenWeatherMapOptions.SectionName).Bind(options);
            });

            services.AddAutoMapper(typeof(MappingProfile));

            services.AddHttpClient();
            services.AddScoped<IWeatherClientService, WeatherClientService>();
            services.AddScoped<IWeatherPollerService, WeatherPollerService>();
            services.AddScoped<IWeatherService, WeatherService>();

            return services;
        }
    }
}
