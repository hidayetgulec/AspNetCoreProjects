using AspNetCoreMvc_View_Model_Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreMvc_View_Model_Web.ViewComponents
{
    public class ProductsViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            List<Product> products = new()
            {
                new() { Id = 1, Name="Lenova i7", Stock=12, Price=42000 },
                new() { Id = 2, Name="Lenova i5", Stock=15, Price=32000},
                new() { Id = 3, Name="IPhone 13", Stock=22, Price=40000},
                new() { Id = 4, Name="IPhone 14", Stock=8, Price=52000},
                new() { Id = 5, Name="Canon Jet", Stock=18, Price=7200},
                new() { Id = 6, Name="Ekran Kartı", Stock=28, Price=2600},
            };
            return View(products); 
        }
    }
}
