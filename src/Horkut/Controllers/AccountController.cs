using Horkut.Service.Account;
using Microsoft.AspNetCore.Mvc;

namespace Horkut.Web.Controllers
{
    public class AccountController : Controller
    {
        
        private IAccountService AccountService { get; set; }
        private IAccountIdentityManager AccountIdentityManager { get; set; }

        public AccountController(IAccountService accountService, IAccountIdentityManager accountIdentityManager)
        {
            this.AccountService = accountService;
            this.AccountIdentityManager = accountIdentityManager;
        }
        
        // GET
        public IActionResult Index()
        {
            return  View();
        }
    }
}    