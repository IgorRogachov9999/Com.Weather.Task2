using Com.Weather.Task2.Domain.Data.Factories.Contracts;
using Com.Weather.Task2.Domain.Data.Factories;
using Com.Weather.Task2.Domain.Data.Options;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Com.Weather.Task2.Domain.Data.UnitOfWork.Contracts;
using Com.Weather.Task2.Domain.Data.UnitOfWork;
using System.Reflection;
using Com.Weather.Task2.Domain.Data.Entities;

namespace Com.Weather.Task2.Domain.Data.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDataLayer(this IServiceCollection services, IConfiguration configuration)
        {
            DapperTypeMap.RegisterType<WeatherInfo>();

            services.AddConnectionFactory(configuration);
            services.AddSingleton<IWeatherUnitOfWork, WeatherUnitOfWork>();

            return services;
        }

        public static IServiceCollection AddConnectionFactory(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<ConnectionStringsOptions>(options =>
            {
                configuration.GetSection(ConnectionStringsOptions.SectionName).Bind(options);
            });

            services.AddSingleton<IConnectionFactory, NpgsqlConnectionFactory>();

            return services;
        }
    }
}
