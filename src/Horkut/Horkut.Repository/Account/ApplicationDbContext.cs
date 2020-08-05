using Horkut.Domain.Account.Repository;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Horkut.Repository.Account
{
    public class ApplicationDbContext : IdentityDbContext, IAccountRepository
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}