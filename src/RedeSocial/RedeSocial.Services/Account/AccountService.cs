﻿using System;
using RedeSocial.Domain.Account.Repository;
using RedeSocial.Repository.Account;

namespace RedeSocial.Services.Account
{
    public class AccountService : IAccountService
    {
        private IAccountRepository accountRepository { get; set; }


        public AccountService(IAccountRepository accountRepository)
        {
            this.accountRepository = accountRepository;
        }

        public void Create(string name, DateTime birthday, string email, string password, string username)
        {
            var userRole = accountRepository.GetRolebyName("USUARIO");
            var newAccount = new Domain.Account.Account(name, birthday, email, password, userRole, username);
            
            accountRepository.CreateAccount(newAccount);
        }
    }
}
