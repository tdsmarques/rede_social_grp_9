using Horkut.Domain.Account.Repository;

namespace Horkut.Service.Account
{
    public class AccountService : IAccountService
    {
        private IAccountRepository AccountRepository { get; set; }

        public AccountService(IAccountRepository accountRepository)
        {
            this.AccountRepository = accountRepository;
        }
    }
}