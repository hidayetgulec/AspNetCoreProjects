using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreMvc_StateManagement.Controllers
{
    public class CookieController : Controller
    {
        CookieOptions options = new CookieOptions();
        public IActionResult Index()
        {
            //Response.Cookies.Append("favoriRenk", "Mavi");
            //Response.Cookies.Append("ugurluSayi", "7");

            options.Expires = DateTime.Now.AddDays(2);

            Response.Cookies.Append("favoriRenk", "Mavi", options);
            Response.Cookies.Append("ugurluSayi", "7", options);

            return RedirectToAction("Results");
        }
        public IActionResult Results()
        {
            ViewBag.renk = Request.Cookies["favoriRenk"];
            ViewBag.sayi = Request.Cookies["ugurluSayi"];
            return View();
        }
    }
}
