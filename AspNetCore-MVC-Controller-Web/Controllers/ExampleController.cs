using Microsoft.AspNetCore.Mvc;

namespace AspNetCore_MVC_Controller_Web.Controllers
{
    public class ExampleController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult ParametreAction(int id)
        {
            return RedirectToAction("JsonResult", new { id = id }); //İsmi belirtilen action metoda döner.
        }
        public IActionResult JsonResult(int id)
        {
            return Json(new { id = id }); //Gelen objeyi json formata çevirerek döndürür.
        }
        public IActionResult ContentResult()
        {
            return Content("Herhangi bir mesaj döndürülebilir."); //Sadece string metin döndürür.
        }
        public IActionResult EmptyResult()
        {
            return new EmptyResult();   //Hata vermez, boş bir sayfa döndürür.
        }

    }
}
