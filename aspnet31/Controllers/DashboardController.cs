using Microsoft.AspNetCore.Mvc;

namespace aspnet31.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
