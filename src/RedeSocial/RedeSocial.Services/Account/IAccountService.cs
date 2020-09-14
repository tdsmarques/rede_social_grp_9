using System;
namespace RedeSocial.Services.Account
{
    public interface IAccountService
    {
        void Create(string name, DateTime birthday, string email, string password, string username, string urlImage);
        Domain.Account.Account GetAccountByUsername(string username);
    }
}
