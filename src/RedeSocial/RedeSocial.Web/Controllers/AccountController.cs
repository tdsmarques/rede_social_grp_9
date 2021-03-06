﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RedeSocial.CrossCuting.Storage;
using RedeSocial.Services.Account;
using RedeSocial.Web.ViewModel.Account;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RedeSocial.Web.Controllers
{
    public class AccountController : Controller
    {
        private IAccountService AccountService { get; set; }
        private IAccountIdentityManager AccountIdentityManager { get; set; }
        private AzureStorage AzureStorage { get; set; }

        public AccountController(IAccountService accountService, IAccountIdentityManager accountIdentityManager, AzureStorage azureStorage)
        {
            AccountService = accountService;
            AccountIdentityManager = accountIdentityManager;
            AzureStorage = azureStorage;
        }

        public IActionResult Login(string returnUrl = "")
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        public IActionResult Reset()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model, string returnUrl)
        {
            try
            {
                var result = await this.AccountIdentityManager.Login(model.UserName, model.Password);

                if (!result.Succeeded)
                {
                    ModelState.AddModelError(string.Empty, "Login ou senha inválidos");
                    return View(model);
                }

                if (!String.IsNullOrWhiteSpace(returnUrl))
                    return Redirect(returnUrl);

                return Redirect("/");
            }
            catch
            {
                ModelState.AddModelError(string.Empty, "Ocorreu um erro, por favor tente mais tarde.");
                return View(model);
            }
            
        }
        
        public IActionResult Create()
        {
            return View();
        }
        
        [HttpGet]
        public async Task<IActionResult> CreateAccount()
        {
            return Redirect("/Account/Create");
        }
        
        [HttpPost]
        public async Task<IActionResult> Create(AccountViewModel model, [FromForm] IFormFile file)
        {
            var ms = new MemoryStream();
            try
            {
                using (var fileUpload = file.OpenReadStream())
                {
                    await fileUpload.CopyToAsync(ms);
                    fileUpload.Close();
                }

                var urlAzure = await this.AzureStorage.SaveToStorage(ms.ToArray(), $"{Guid.NewGuid().ToString().Replace("-", "")}.jpg");
                AccountService.Create(model.Name, model.Birthday, model.Email, model.Password, model.UserName, urlAzure);
                
                
                return Redirect("/Account/Login");
            }
            catch
            {
                ModelState.AddModelError(string.Empty, "Ocorreu um erro, por favor tente mais tarde.");
                return View(model);
            }
            
        }
    }
}
