using System.Threading.Tasks;
using api_dictionary.Application.Common.Models;
using api_dictionary.Application.Dto;

namespace api_dictionary.Application.Common.Interfaces
{
    public interface IIdentityService
    {
        Task<string> GetUserNameAsync(string userId);

        Task<ApplicationUserDto> CheckUserPassword(string userName, string password);

        Task<(Result Result, string UserId)> CreateUserAsync(string firstName, string lastName, string email, string password);

        Task<bool> IsUserEmailExistAsync(string userId);

        Task<bool> UserIsInRole(string userId, string role);

        Task<Result> DeleteUserAsync(string userId);
    }
}
