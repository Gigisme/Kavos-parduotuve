using Microsoft.AspNetCore.Mvc;
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
            return View();
        }
        public IActionResult Delete()
        {
            return View();
        }
        
        public IActionResult Update()
        {
            return View();
        }
    }
}
