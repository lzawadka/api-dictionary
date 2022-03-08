using System.Threading.Tasks;
using api_dictionary.Application.Common.Models;

namespace api_dictionary.Application.Common.Interfaces
{
    public interface IEmailService
    {
        Task SendAsync(EmailRequest request);
    }
}
