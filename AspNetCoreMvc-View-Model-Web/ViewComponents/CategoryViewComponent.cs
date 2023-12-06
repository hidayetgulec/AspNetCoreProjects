using AspNetCoreMvc_View_Model_Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreMvc_View_Model_Web.ViewComponents
{
    public class CategoryViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            List<Category> categories = new()
            {
                new() { Id = 1, Name="Bilgisayarlar", Description="Çeşitli bilgisayarlar"},
                new() { Id = 2, Name="Telefonlar", Description="Çeşitli telefonlar"},
                new() { Id = 3, Name="Yazıcılar", Description="Çeşitli yazıcılar"},
                new() { Id = 4, Name="OEM Parçalar", Description="Çeşitli parçalar"}
            };
            return View(categories);
        }
    }
}
