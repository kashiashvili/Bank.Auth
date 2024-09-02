using MediatR;

namespace Bank.Auth.Domain;

public class RegisterCommand : IRequest<Response>
{
    public required string Firstname { get; set; }

    public required string Lastname { get; set; }

    public required string PersonalNumber { get; set; }

    public DateTime BirthDate { get; set; }

    public required string Username { get; set; } //TODO: fluent validations

    public required string Email { get; set; }

    public required string Password { get; set; }
}