using AspNetCoreMvc_View_Model_Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace AspNetCoreMvc_View_Model_Web.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        //public IActionResult Create(int Id, string Name, string Description)
        public IActionResult Create()
        {
            //1. Yöntem : Querystring
            //Form HttpGet metodu ile gönderilirse, sayfadaki name'lerle birlikte veriler tarayıcının url adresinde ? den sonra eklenerek action'a taşınır. baseUrl/Category/Create?Id=5&Name=aaaa&Description=bbb gibi.
            //Formdaki name'lerle aynı isimde parametreler tanımlanmış olmalı.

            //Category c = new Category();
            //c.Id = Id;
            //c.Name = Name;
            //c.Description = Description;

            return View();
        }

        [HttpPost]
        //public IActionResult Create(int Id, string Name, string Description)
        //{
        public IActionResult Create(Category model) 
        { 
            //2. Yöntem : HttpContext.Request.Form

            //var Id = HttpContext.Request.Form["Id"].ToString();
            //var Name = HttpContext.Request.Form["Name"].ToString();
            //var Desc = HttpContext.Request.Form["Description"].ToString();

            //3. Yöntem : Parameters

            //Category c = new Category();
            //c.Id = Id;
            //c.Name = Name;
            //c.Description = Description;

            //4. Yöntem : Model
            //View sayfasında kullanılan model (Category), sayfa post edildiğinde, backend tarafında HttpPost ile çelışan action metodun model (Category) parametresine taşınır.

            string name = model.Name;

            //Categories.Add(model);


            return View();
        }
    }
}
