using aspnet31.Models;
using aspnet31.Repositories.Data;
using aspnet31.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace aspnet31.Controllers
{
    public class AccountController : Controller
    {
        AccountRepository accountRepository;
        HttpClientHandler _clientHandler = new HttpClientHandler();

        public AccountController(AccountRepository accountRepository)
        {
            this.accountRepository = accountRepository;
            _clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
        }

        [HttpGet("/Account")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Index(User users)//post login
        {
            Login login = new Login();
            login.Username = users.Username;
            login.Password = users.Password;
            using (var client = new HttpClient(_clientHandler))
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(login), Encoding.UTF8, "application/json");

                using (var response = await client.PostAsync("https://localhost:44318/api/Account/", content))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    var parsedObject = JObject.Parse(apiResponse);
                    var token = parsedObject["token"].ToString();

                    HttpContext.Session.SetString("Token", token);
                }
            }
            string test = HttpContext.Session.GetString("Token");
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Register()
        {
            return View();
        }
    }
}
