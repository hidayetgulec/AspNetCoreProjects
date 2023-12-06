using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreMvc_View_Model_Web.ViewComponents
{
    public class XXXViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {

            return View();
        }
    }
}
