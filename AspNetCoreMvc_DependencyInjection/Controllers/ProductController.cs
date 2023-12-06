using AspNetCoreMvc_DependencyInjection.Interfaces;
using AspNetCoreMvc_DependencyInjection.Models;
using AspNetCoreMvc_DependencyInjection.Repositories;
using AspNetCoreMvc_DependencyInjection.ViewModels;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreMvc_DependencyInjection.Controllers
{
    public class ProductController : Controller
    {
        //ProductRepository _productRepo = new ProductRepository();
        //Somut (concrete) nesneler (ProductRepository) yerine soyut (abstract/interface) nesneleri (IProductRepository) kullanarak bağımlılığı azaltıyoruz ve projenin farklı teknolojilere uyum sürecini kısaltıyoruz. 

        private readonly IProductRepository _productRepo;
        private readonly IMapper _mapper;
        public ProductController(IProductRepository productRepo, IMapper mapper)
        {
            _productRepo = productRepo;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            var products = _productRepo.GetAllProducts();

            //foreach (var product in products)
            //{
            //    liste.Add( new ProductViewModel(){Id = product.Id, Name = product.Name, gibi, gibi...);
            //}

            return View(_mapper.Map<List<ProductViewModel>>(products));
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
