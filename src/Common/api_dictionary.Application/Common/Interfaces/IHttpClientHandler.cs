using System.Threading;
using System.Threading.Tasks;
using api_dictionary.Application.Common.Models;
using api_dictionary.Domain.Enums;

namespace api_dictionary.Application.Common.Interfaces
{
    public interface IHttpClientHandler
    {
        Task<ServiceResult<TResult>> GenericRequest<TRequest, TResult>(string clientApi, string url,
            CancellationToken cancellationToken,
            MethodType method = MethodType.Get,
            TRequest requestEntity = null)
            where TResult : class where TRequest : class;
    }
}