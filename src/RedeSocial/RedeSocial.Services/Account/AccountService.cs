using System;
using RedeSocial.Domain.Account.Repository;

namespace RedeSocial.Services.Account
{
    public class AccountService : IAccountService
    {
        private IAccountRepository accountRepository { get; set; }


        public AccountService(IAccountRepository accountRepository)
        {
            this.accountRepository = accountRepository;
        }

    }
}
