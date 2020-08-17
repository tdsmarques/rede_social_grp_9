using Horkut.Repository.Mapping;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Horkut.Repository.Context
{
    public class HorkutContext : DbContext
    {
        public DbSet<Domain.Account.Account> Accounts { get; set; }
        public DbSet<Domain.Account.Profile> Profiles { get; set; }

        public static readonly ILoggerFactory _loggerFactory
            = LoggerFactory.Create(builder => { builder.AddConsole(); });
 
        public HorkutContext(DbContextOptions<HorkutContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLoggerFactory(_loggerFactory);
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AccountMap());
            modelBuilder.ApplyConfiguration(new ProfileMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}