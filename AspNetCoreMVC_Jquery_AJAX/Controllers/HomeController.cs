using AspNetCoreMVC_Jquery_AJAX.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AspNetCoreMVC_Jquery_AJAX.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Edit() 
        {
            Product urun = new Product()
            {
                Id = 1,
                Name = "IPhone 14",
                Stock = 20
            };
            return View(urun);
        }
        [HttpGet]
        public IActionResult SepeteEkle(string Id, string Adet)
        {
            //Gelen Adet navbar'da sepet için ayrılan bölüme eklenir. 
            ViewBag.sepet = Adet;
            return View("SepetiYenile");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}