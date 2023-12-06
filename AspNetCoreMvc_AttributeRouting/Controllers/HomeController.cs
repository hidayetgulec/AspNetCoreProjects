using AspNetCoreMvc_AttributeRouting.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AspNetCoreMvc_AttributeRouting.Controllers
{
    [Route("[controller]/[action]")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        [Route("/")]     //baseUrl -> https://www.abc.com
        [Route("/Home")]
        [Route("/Home/Index")]
        //[Route("{id?}")]
        [HttpGet("{id?}")]
        public IActionResult Index(int? id)
        {
            return View();
        }
        //[Route("/Anasayfa/Ozel/{id}/{name}", Name ="path")]
        //[Route("/Anasayfa/Ozel/{id}/{name}")]
        [Route("/Ozel/{id}/{name}")]

        public IActionResult Privacy(int id, string name)
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}