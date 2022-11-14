using Microsoft.AspNetCore.Mvc;

namespace MvcMovie.Controllers
{
    public class RekomendacijosController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
