using lab11_mvc.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lab11_mvc.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(int price, int points)
        {

            return RedirectToAction("WineResults", new { price, points});
            
        }
        [HttpGet]
        public IActionResult WineResults(int price, int points)
        {
            return View(Models.Wine.ProcessData(price, points));
        }

    }
}
