using Microsoft.AspNetCore.Mvc;

namespace MvcMovie.Controllers
{
    public class RegistracijaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
