using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using RedeSocial.CrossCuting.Storage;
using RedeSocial.Domain.Post;
using RedeSocial.Services.Account;
using RedeSocial.Web.Models;
using RedeSocial.Web.ViewModel.Post;

namespace RedeSocial.Web.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IAccountService AccountService { get; set; }
        private AzureStorage AzureStorage { get; set; }
        private readonly HttpClient httpClient;
        
        
        
        public HomeController(ILogger<HomeController> logger, IAccountService accountService, AzureStorage azureStorage)
        {
            _logger = logger;
            AccountService = accountService;
            AzureStorage = azureStorage;
            httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("https://localhost:64320");
        }
        
        public async Task<IActionResult> Index()
        {
            var viewModel = new TimeLineViewModel();
            var user = AccountService.GetAccountByUsername(User.Identity.Name);
            var response = await httpClient.GetAsync("api/post");
            
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var content = await response.Content.ReadAsStringAsync();
                var posts = JsonConvert.DeserializeObject<List<Post>>(content);

                viewModel.Posts = posts;
                viewModel.UserLoggedIn = user;
            }
            return View(viewModel);
        }
        //Somente para testes 
        public IActionResult Comment()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }
        
        public IActionResult Post()
        {
            return View();
        }
        
        [HttpPost]
        public async Task<IActionResult> Post(PostViewModel model, [FromForm] IFormFile file)
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
                
                model.ImageUrl = urlAzure;
                model.userName = User.Identity.Name;
                
                var postRequest = JsonConvert.SerializeObject(model);
                var content = new StringContent(postRequest, Encoding.UTF8, "application/json");
                var response = await httpClient.PostAsync("api/post", content);
                
                
                if (!response.IsSuccessStatusCode)
                {
                    return Redirect("/Home/Index");
                }
            }
            catch
            {
                ModelState.AddModelError(string.Empty, "Ocorreu um erro, por favor tente mais tarde.");
            }
            return Redirect("/");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
