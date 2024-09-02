using MediatR;

namespace Bank.Auth.Domain;

public class LoginQuery : IRequest<LoginResponse> //TODO possibly move it to app layer
{
    public required string Username { get; set; }

    public required string Password { get; set; }
}