using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using RedeSocial.Repository.Mapping;

namespace RedeSocial.Repository.Context
{
    public class RedeSocialContext : DbContext
    {
        public DbSet<Domain.Account.Account> Accounts { get; set; }
        public DbSet<Domain.Account.Role> Roles { get; set; }
        
        public static readonly ILoggerFactory LoggerFactory =
            Microsoft.Extensions.Logging.LoggerFactory.Create(builder => { builder.AddConsole(); });
        
        public RedeSocialContext(DbContextOptions<RedeSocialContext> options) : base(options)
        {
            
        }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLoggerFactory(LoggerFactory);
            base.OnConfiguring(optionsBuilder);
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AccountMap());
            modelBuilder.ApplyConfiguration(new RoleMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}