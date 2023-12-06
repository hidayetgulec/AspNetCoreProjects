using AspNetCoreMvc_EF_Stock.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreMvc_EF_Stock.ViewComponents
{
    public class CategoriesViewComponent : ViewComponent
    {
        CategoryRepository _categoryRepo = new CategoryRepository();
        public async Task<IViewComponentResult> InvokeAsync()
        {
            ViewBag.SelectedCategoryId = RouteData?.Values["id"];
            var categories = _categoryRepo.GetAllCategories();
            return View(categories);
        }
    }
}
