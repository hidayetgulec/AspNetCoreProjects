using AspNetCoreMvc_View_Model_Web.Models;
using AspNetCoreMvc_View_Model_Web.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreMvc_View_Model_Web.Controllers
{
    public class ProductController : Controller
    {
        List<Category> categories = new()
        {
            new() { Id = 1, Name="Bilgisayarlar", Description="Çeşitli bilgisayarlar"},
            new() { Id = 2, Name="Telefonlar", Description="Çeşitli telefonlar"},
            new() { Id = 3, Name="Yazıcılar", Description="Çeşitli yazıcılar"},
            new() { Id = 4, Name="OEM Parçalar", Description="Çeşitli parçalar"}
        };

        List<Product> products = new()
        {
            new() { Id = 1, Name="Lenova i7", Stock=12, Price=42000 },
            new() { Id = 2, Name="Lenova i5", Stock=15, Price=32000},
            new() { Id = 3, Name="IPhone 13", Stock=22, Price=40000},
            new() { Id = 4, Name="IPhone 14", Stock=8, Price=52000},
            new() { Id = 5, Name="Canon Jet", Stock=18, Price=7200},
            new() { Id = 6, Name="Ekran Kartı", Stock=28, Price=2600},
        };
        public IActionResult Index()
        {
            //ViewBag.Categories = categories;

            //Product_Category_ViewModel pc_ViewModel = new Product_Category_ViewModel();
            //pc_ViewModel.Products = products;
            //pc_ViewModel.Categories = categories;

            Product_Category_ViewModel pc_ViewModel = new()
            {
                Categories = categories,
                Products = products
            };

            return View(pc_ViewModel);
        }
        public IActionResult Details()
        {
            ViewBag.name = "Iphone 14";

            ViewBag.Categories = categories;

            Product product = products[0];

            return View(product);
        }
        public IActionResult Contact()
        {
            return View();
        }
    }
}
