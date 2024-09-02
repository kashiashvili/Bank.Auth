using Bank.Auth.Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Bank.Auth.Persistence;

public class ApplicationDbContext : IdentityDbContext<BankIdentityUser>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<BankIdentityUser>().Property(e => e.Firstname).HasMaxLength(300);
        builder.Entity<BankIdentityUser>().Property(e => e.Lastname).HasMaxLength(300);
        builder.Entity<BankIdentityUser>().Property(e => e.PersonalNumber).HasMaxLength(30);

        base.OnModelCreating(builder);
    }
}