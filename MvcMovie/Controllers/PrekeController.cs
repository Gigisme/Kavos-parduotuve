using Microsoft.AspNetCore.Mvc;
using MvcMovie.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcMovie.Controllers
{
    public class PrekeController : Controller
    {
        public IActionResult Insert()
        {
            return View();
        }
        public IActionResult Index()
        {
            List<Preke> prekes = new List<Preke>();
            Preke preke1 = new Preke() {
                Id = 1,
                Name = "Juoda kava",
                Description = "Juodos kavos aprašymas",
                Price = 10,
                Image = "https://th.bing.com/th/id/OIP.KFKc9jvI80ikP11fFkS3OAHaFL?pid=ImgDet&rs=1"
            };

            Preke preke2 = new Preke()
            {
                Id = 2,
                Name = "Šalta kava",
                Description = "Šaltos kavos aprašymas",
                Price = 10,
                Image = "https://th.bing.com/th/id/R.4b4588b4556198eefea8ce8dedcb300d?rik=t26ceZLoBPtjHA&pid=ImgRaw&r=0"
            };
            prekes.Add(preke1);
            prekes.Add(preke2);

            return View(prekes);
        }
        public IActionResult Details()
        {
            return View();
        }
        public IActionResult Delete()
        {
            return View();
        }
        
        public IActionResult Update(Preke preke)
        {
            return View(preke);
        }
        public IActionResult BuyAd()
        {
            return View();
        }


    }
}
