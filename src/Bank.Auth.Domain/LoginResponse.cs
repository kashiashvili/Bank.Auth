namespace Bank.Auth.Domain;

public class LoginResponse
{
    public LoginResponse(string token)
    {
        Token = token;
    }

    public string Token { get; set; }
}