using Microsoft.AspNetCore.Mvc;
using MvcMovie.db;
using MvcMovie.Models;
using MvcMovie.Views;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

namespace MvcMovie.Controllers
{
    public class PrekeController : Controller
    {
        private readonly Db _db;

        public PrekeController(Db db)
        {
            _db = db;
        }

        public IActionResult Insert()
        {
            return View();
        }
        public IActionResult Index()
        {          
            var products = _db.GetProducts();
            return View(products);
        }
        public IActionResult Details(int id)
        {
            var product = _db.GetProductById(id);
            
            if (product == null)
            {
                return NotFound();
            }

            var displayImageVM = new DisplayImageVM() { Product = product };

            if (product.Image != null)
            {
                displayImageVM.ImageHex = $"data:image/jpeg;base64,{Convert.ToBase64String(product.Image)}";
            } else
            {
                displayImageVM.ImageHex = null;
            }

            product.Image = null;
            return View(displayImageVM);
        }
        public IActionResult Delete(int id)
        {
            int deleted = _db.DeleteProduct(id);
            if(deleted > 0 || deleted == 0)
            {
                return RedirectToAction(controllerName: "Preke", actionName: "Index");
            }
            return View();
        }

        public IActionResult Update(int id)
        {
            var product = _db.GetProductById(id);

            return View(product);
        }

        [HttpPost]
        public IActionResult Update(Preke product)
        {
            var updated = _db.UpdateProduct(product);

            return RedirectToAction(controllerName: "Preke", actionName: "Details", routeValues: new { id = product.Id });
        }


        public IActionResult BuyAd(int id)
        {
            var product = _db.GetProductById(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        [HttpPost]
        public IActionResult BuyAd(Reklama ad)
        {
            ad.From = DateTime.Now;
            ad.To = DateTime.Now.AddDays(int.Parse(ad.ToStr) * 7);
            _db.CreateAd(ad);

            return RedirectToAction(controllerName: "Preke", actionName: "Details", routeValues: new { id = ad.Fk_product });
        }

        [HttpPost]
        public IActionResult Filtered(string input1, string input2)
        {
            int in1 = int.Parse(input1);
            int in2 = int.Parse(input2);
            var filteredProducts = _db.FilterProducts(in1, in2);
            return View(filteredProducts);
        }

        private static async Task<byte[]> GetBytes(IFormFile formFile)
        {
            await using var memoryStream = new MemoryStream();
            await formFile.CopyToAsync(memoryStream);
            return memoryStream.ToArray();
        }

        [HttpPost]
        public async Task<IActionResult> Insert(Preke product)
        {
            var files = Request.Form.Files;

            if (files.Count == 0 || files.Count > 1)
            {
                return BadRequest();
            }

            var bytes = await GetBytes(files[0]);
            //var hexString = Convert.ToBase64String(bytes);
            product.Image = bytes;
            _db.AddProduct(product);
            return Redirect("Index");
        }
    }
}
