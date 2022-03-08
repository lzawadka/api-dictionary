using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using api_dictionary.Application.ApplicationUser.Commands.Create;
using api_dictionary.Application.Common.Interfaces;
using api_dictionary.Application.Common.Models;
using MediatR;

namespace api_dictionary.Application.Users.Commands.CreateUser;
public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, string>
{
    private readonly IIdentityService _identityService;
    public CreateUserCommandHandler(IIdentityService identityService)
    {
        _identityService = identityService;
    }

    public async Task<string> Handle(CreateUserCommand command, CancellationToken cancellationToken)
    {
        bool isExistingUserByEmail = await _identityService.IsUserEmailExistAsync(command.Email);

        if(isExistingUserByEmail)
             throw new Exception($"Email {command.Email} is already in use");

        var createUserResult = await _identityService.CreateUserAsync(command.FirstName, command.LastName, command.Email, command.Password);

        return createUserResult.UserId;
    }
}
