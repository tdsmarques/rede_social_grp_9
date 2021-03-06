﻿using System;
using System.Threading.Tasks;

namespace RedeSocial.Domain.Account.Repository
{
    public interface IAccountRepository
    {
        Task<Account> GetAccountByEmailPassword(string email, string password);
        Task<Domain.Account.Account> GetAccountByUserNamePassword(string userName, string password);
        Role GetRolebyName(String name);
        void CreateAccount(Account account);
        Account GetAccountbyName(String name);
    }
}
