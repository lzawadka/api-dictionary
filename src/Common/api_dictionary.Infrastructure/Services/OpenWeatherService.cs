using System.Threading;
using System.Threading.Tasks;
using api_dictionary.Application.Common.Interfaces;
using api_dictionary.Application.Common.Mapping;
using api_dictionary.Application.Common.Models;
using api_dictionary.Application.ExternalServices.OpenWeather.Request;
using api_dictionary.Application.ExternalServices.OpenWeather.Response;
using api_dictionary.Domain.Enums;

namespace api_dictionary.Infrastructure.Services
{
    public class OpenWeatherService : IOpenWeatherService
    {
        private readonly IHttpClientHandler _httpClient;

        private string ClientApi { get; } = "open-weather-api";

        public OpenWeatherService(IHttpClientHandler httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ServiceResult<OpenWeatherResponse>> GetCurrentWeatherForecast(OpenWeatherRequest request, CancellationToken cancellationToken)
        {
            return await _httpClient.GenericRequest<OpenWeatherRequest, OpenWeatherResponse>(ClientApi, string.Concat("weather?", StringExtensions
                .ParseObjectToQueryString(request, true)), cancellationToken, MethodType.Get, request);
        }
    }
}