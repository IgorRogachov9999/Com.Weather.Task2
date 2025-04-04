using Com.Weather.Task2.Domain.Services.Dto.Client;
using Com.Weather.Task2.Domain.Services.Options;
using Com.Weather.Task2.Domain.Services.Services.Contracts;
using Microsoft.Extensions.Options;
using Polly;
using System.Text.Json;

namespace Com.Weather.Task2.Domain.Services.Services
{
    public class WeatherClientService : IWeatherClientService
    {
        private readonly HttpClient _httpClient;
        private readonly OpenWeatherMapOptions _openWeatherMapOptions;

        public WeatherClientService(IHttpClientFactory factory, IOptionsMonitor<OpenWeatherMapOptions> options)
        {
            _openWeatherMapOptions = options.CurrentValue;
            _httpClient = factory.CreateClient();
            _httpClient.BaseAddress = new Uri(_openWeatherMapOptions.BaseUrl);
        }

        public async Task<WeatherResponseDto> GetWeatherDataAsync(CancellationToken ct)
        {
            var policy = Policy
                .Handle<HttpRequestException>()
                .OrResult<HttpResponseMessage>(x => !x.IsSuccessStatusCode)
                .WaitAndRetryAsync(
                    retryCount: 3,
                    sleepDurationProvider: x => TimeSpan.FromSeconds(Math.Pow(1, x)));

            var response = await policy.ExecuteAsync(() =>
                _httpClient.GetAsync($"data/2.5/group?id={_openWeatherMapOptions.CityIds}&appid={_openWeatherMapOptions.ApiKey}", ct));

            return await GetWeatherResponse(response, ct);
        }

        private async Task<WeatherResponseDto> GetWeatherResponse(HttpResponseMessage response, CancellationToken ct)
        {
            if (!response.IsSuccessStatusCode)
            {
                return null;
            }

            var json = await response.Content.ReadAsStringAsync(ct);
            return JsonSerializer.Deserialize<WeatherResponseDto>(json, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
        }
    }
}
