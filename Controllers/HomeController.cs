using Microsoft.AspNetCore.Mvc;

namespace Timely_v1.Controllers
{
    public class HomeController : Controller
    {
        public HomeController() { }

        public IActionResult Index() => View();
    }
}