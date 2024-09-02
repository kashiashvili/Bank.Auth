using Bank.Auth.Domain;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;

namespace Bank.Auth.Application.Auth.Commands.Register;

public class RegisterCommandHandler : IRequestHandler<RegisterCommand, Response>
{
    private readonly ILogger<RegisterCommandHandler> _logger;
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly UserManager<BankIdentityUser> _userManager;

    public RegisterCommandHandler(
        UserManager<BankIdentityUser> userManager,
        RoleManager<IdentityRole> roleManager,
        ILogger<RegisterCommandHandler> logger)
    {
        _userManager = userManager;
        _roleManager = roleManager;
        _logger = logger;
    }

    public async Task<Response> Handle(RegisterCommand request, CancellationToken cancellationToken)
    {
        var userExists = await _userManager.FindByNameAsync(request.Username);
        if (userExists != null)
            throw new Exception(); //TODO add global error handler and Domain exception

        BankIdentityUser user = new(request.Firstname, request.Lastname, request.PersonalNumber, request.BirthDate)
        {
            Email = request.Email,
            UserName = request.Username
        };
        var result = await _userManager.CreateAsync(user, request.Password);
        if (!result.Succeeded)
        {
            foreach (var error in result.Errors)
                _logger.LogError($"User creation failed with error code '{error.Code}': {error.Description}");

            throw new Exception(); //TODO change exception type "User creation failed! Please check user details and try again." });
        }

        if (!await _roleManager.RoleExistsAsync(UserRoles.User))
            await _roleManager.CreateAsync(new IdentityRole(UserRoles.User));

        await _userManager.AddToRoleAsync(user, UserRoles.User);

        return new Response { Status = "Success", Message = "User created successfully!" };
    }
}