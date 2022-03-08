using MediatR;

namespace api_dictionary.Application.Users.Commands.CreateUser;
public class CreateUserCommand : IRequest<string>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
}
