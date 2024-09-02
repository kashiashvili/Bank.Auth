using Microsoft.AspNetCore.Identity;

namespace Bank.Auth.Domain;

public class BankIdentityUser : IdentityUser
{
    public BankIdentityUser(string firstname, string lastname, string personalNumber, DateTime birthDate)
    {
        Firstname = firstname;
        Lastname = lastname;
        PersonalNumber = personalNumber;
        BirthDate = birthDate;
    }

    public string Firstname { get; private set; }

    public string Lastname { get; private set; }

    public string PersonalNumber { get; private set; }

    public DateTime BirthDate { get; private set; }
}