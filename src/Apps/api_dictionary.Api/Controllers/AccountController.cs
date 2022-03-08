using api_dictionary.Api.Controllers;
using api_dictionary.Application.Users.Commands.CreateUser;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace dictionary_api.WebAPI.Controllers;
[Route("api/[controller]")]
[ApiController]
public class AccountController : BaseApiController
{
    [HttpPost("[action]")]
    public async Task<ActionResult<string>> Create(CreateUserCommand command)
    {
        return Ok(await Mediator.Send(command));
    }
}
