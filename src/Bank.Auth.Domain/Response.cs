namespace Bank.Auth.Domain;

public class Response
{
    public required string Status { get; set; }
    public string? Message { get; set; }
}