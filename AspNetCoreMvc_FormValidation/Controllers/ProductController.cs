using AspNetCoreMvc_FormValidation.Models;
using AspNetCoreMvc_FormValidation.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreMvc_FormValidation.Controllers
{
    public class ProductController : Controller
    {
        ProductRepository _productRepo = new ProductRepository();
        public IActionResult Index()
        {
            var products = _productRepo.GetAllProducts();
            return View(products);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Product model)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Ürün kayıt edilemedi.");
                return View(model);
            }
            _productRepo.Add(model);
            return RedirectToAction("Index");
        }
    }
}
