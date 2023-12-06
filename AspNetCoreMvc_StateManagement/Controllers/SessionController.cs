using AspNetCoreMvc_StateManagement.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace AspNetCoreMvc_StateManagement.Controllers
{
    public class SessionController : Controller
    {
        public IActionResult Index()
        {
            HttpContext.Session.SetString("username", "erkan");
            HttpContext.Session.SetInt32("password", 321);

            List<string> ogrenciler = new List<string>() { "Ali Uçar", "Oya Koşar", "Necati Yılmaz" };
            HttpContext.Session.SetString("liste", JsonConvert.SerializeObject(ogrenciler));
            //Object notasyonlu komplex veriler sesion'a atılmadan önce serialize (json, binary, xml gibi) edilmelidir.

            List<Product> urunler = new List<Product>()
            {
                new() {Id=1, Name="Bilgisayar"},
                new() {Id=2, Name="Telefon"},
                new() {Id=3, Name="Yazıcı"}
            };
            HttpContext.Session.SetString("products", JsonConvert.SerializeObject(urunler));

            return RedirectToAction("Results");
        }
        public IActionResult Results()
        {
            ViewBag.user = HttpContext.Session.GetString("username");
            ViewBag.pwd = HttpContext.Session.GetInt32("password");

            var ogrenciListesi = HttpContext.Session.GetString("liste");

            ViewBag.liste1 = ogrenciListesi;
            var liste2 = JsonConvert.DeserializeObject<List<string>>(ogrenciListesi);
            ViewBag.liste2 = liste2;

            var products = HttpContext.Session.GetString("products");
            ViewBag.urun1 = products;
            var products2 = JsonConvert.DeserializeObject<List<Product>>(products);
            ViewBag.urun2 = products2;

            return View();
        }
    }
}
