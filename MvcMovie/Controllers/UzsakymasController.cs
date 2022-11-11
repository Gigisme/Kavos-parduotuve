using Microsoft.AspNetCore.Mvc;
using MvcMovie.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcMovie.Controllers
{
    public class UzsakymasController : Controller
    {
        public IActionResult Index()
        {
            List<Uzsakymas> uzsakymas = new List<Uzsakymas>();
            Uzsakymas uzsakymas1 = new Uzsakymas() {
                Id = 1,
                Date = DateTime.Today,
                Price = 10,
                Status = "Vykdomas",
                Rated = false
            };

            Uzsakymas uzsakymas2 = new Uzsakymas()
            {
                Id = 2,
                Date = DateTime.Today,
                Price = 10,
                Status = "Vykdomas",
                Rated = false
            };
            uzsakymas.Add(uzsakymas1);
            uzsakymas.Add(uzsakymas2);

            return View(uzsakymas);
        }
    }
}
