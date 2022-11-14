using Microsoft.AspNetCore.Mvc;

namespace MvcMovie.Controllers
{
    public class KrepselisController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Buy()
        {
            return View();
        }
    }
}
