using System.Threading;
using System.Threading.Tasks;
using api_dictionary.Application.Common.Models;
using api_dictionary.Application.ExternalServices.OpenWeather.Request;
using api_dictionary.Application.ExternalServices.OpenWeather.Response;

namespace api_dictionary.Application.Common.Interfaces
{
    public interface IOpenWeatherService
    {
        Task<ServiceResult<OpenWeatherResponse>> GetCurrentWeatherForecast(OpenWeatherRequest request,
            CancellationToken cancellationToken);
    }
}