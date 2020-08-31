using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RedeSocial.Domain.Account.Repository;

namespace RedeSocial.Repository.Account
{
    public class ApplicationDbContext : IdentityDbContext, IAccountRepository
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}
