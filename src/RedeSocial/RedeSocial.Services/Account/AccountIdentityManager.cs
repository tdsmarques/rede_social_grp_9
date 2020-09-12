using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using RedeSocial.Domain.Account.Repository;

namespace RedeSocial.Services.Account
{
    public class AccountIdentityManager : IAccountIdentityManager
    {
        private IAccountRepository Repository { get; set; }
        private SignInManager<Domain.Account.Account> SignInManager { get; set; }

        public AccountIdentityManager(IAccountRepository accountRepository, SignInManager<Domain.Account.Account> signInManager)
        {
            this.Repository = accountRepository;
            this.SignInManager = signInManager;

        }

        public async Task<SignInResult> Login(string userName, string password)
        {
            var account = await this.Repository.GetAccountByUserNamePassword(userName, password);

            if (account == null)
            {
                return SignInResult.Failed;
            }

            await SignInManager.SignInAsync(account, false);
            return SignInResult.Success;
            
        }
    }
}