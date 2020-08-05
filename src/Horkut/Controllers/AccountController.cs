using Horkut.Service.Account;
using Microsoft.AspNetCore.Mvc;

namespace Horkut.Web.Controllers
{
    public class AccountController : Controller
    {
        
        private IAccountService AccountService { get; set; }

        public AccountController(IAccountService accountService)
        {
            this.AccountService = accountService;
        }
        
        // GET
        public IActionResult Index()
        {
            return View();
        }
    }
}