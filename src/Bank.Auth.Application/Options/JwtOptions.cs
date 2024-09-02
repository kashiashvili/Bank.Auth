namespace Bank.Auth.Application.Options;

public class JwtOptions
{
    public required string ValidIssuer { get; set; }
    public required string ValidAudience { get; set; }
    public required string Secret { get; set; }
}