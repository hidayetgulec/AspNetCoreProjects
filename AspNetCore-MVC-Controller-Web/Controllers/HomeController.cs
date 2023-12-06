using AspNetCore_MVC_Controller_Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AspNetCore_MVC_Controller_Web.Controllers
{
    public class HomeController : Controller
    {


        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        List<Person> persons = new()
        {
            new() { Id = 1, Ad = "Ali", Soyad = "Uçar", Telefon = "532 1646473", Sehir="İstanbul"},
            new() { Id = 2, Ad = "Ayşe", Soyad = "Koşar", Telefon = "543 3646473", Sehir="İstanbul"},
            new() { Id = 3, Ad = "Neşe", Soyad = "Sever", Telefon = "544 2646473", Sehir="İzmir"},
            new() { Id = 4, Ad = "Hasan", Soyad = "Yılmaz", Telefon = "545 1646473", Sehir="Ankara"}
        };
        public IActionResult Index()
        {
            ViewBag.adi = "Neşe";       //Dinamik olarak runtime sırasında oluşturuluyor.
            ViewBag.soyadi = "Sever";   //Başka bir view yada action'a bilgi aktaramaz.

            ViewBag.ogrenci = new { ad = "Ali", soyad = "Uçar", yas = 30 };

            ViewData["telefon"] = "543 4564644"; //Başka bir view yada action'a bilgi aktaramaz.

            ViewData["musteriler"] = new List<string>() { "Oya Koşar", "Necati Coşar", "Ayşe Sever" };

            TempData["adres"] = "İstanbul";     //Başka bir view yada action'a da bilgi aktarabilir. Çalışması sorunludur, yönlendirmenin kesin olmasını arayabilir.

            return View();
        }
        public IActionResult Privacy()
        {
            //var adr = TempData["adres"];     //Veri aktarımı sırasında dönüştürme (cast) isteyebilir.
            //var job  = TempData["meslek"];

            return View();
        }
        public IActionResult Index2()
        {
            TempData["meslek"] = "Öğrenci";
            return RedirectToAction("Privacy");
        }
        public IActionResult Index3()
        {
            return View("Goster");
        }

        public IActionResult GetPerson()
        {
            //Person p = new() { Id = 1, Ad = "Hasan", Soyad = "Yılmaz", Telefon = "532 4545451", Sehir = "İstanbul" };

            Person person = new Person();
            person.Id = 1;
            person.Ad = "Hasan";
            person.Soyad = "Yılmaz";
            person.Telefon = "532 4564641";
            person.Sehir = "İstanbul";

            //ViewData["personel"] = person;

            return View(person);
        }
        public IActionResult GetAllPerson()
        {
            return View(persons);
        }
        public IActionResult GetAllPersonal()
        {
            return View(persons);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}