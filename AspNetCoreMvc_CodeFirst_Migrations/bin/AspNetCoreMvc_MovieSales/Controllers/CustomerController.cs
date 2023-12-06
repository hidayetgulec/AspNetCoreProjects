using AspNetCoreMvc_MovieSales.Interfaces;
using AspNetCoreMvc_MovieSales.Models;
using AspNetCoreMvc_MovieSales.ViewModels;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreMvc_MovieSales.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerRepository _customerRepo;
        private readonly IMovieSaleRepository _movieSaleRepo;
        private readonly IMovieSaleDetailRepository _movieSaleDetailRepo;
        private readonly IMapper _mapper;

        public CustomerController(ICustomerRepository customerRepo, IMapper mapper, IMovieSaleRepository movieSaleRepo, IMovieSaleDetailRepository movieSaleDetailRepo)
        {
            _customerRepo = customerRepo;
            _mapper = mapper;
            _movieSaleRepo = movieSaleRepo;
            _movieSaleDetailRepo = movieSaleDetailRepo;
        }

        public IActionResult Index()
        {

            return View();
            //var customers = _customerRepo.GetAll();
            //return View(_mapper.Map<List<CustomerViewModel>>(customers));
        }
        public IActionResult Login()
        {

            return View();
        }
        [HttpPost]
        public IActionResult Login(CustomerLoginViewModel model)
        {
            if(ModelState.IsValid)
            {
                var customer = _customerRepo.GetAll().FirstOrDefault(c => c.Email == model.Email && c.Password == model.Password);
                if(customer == null)
                {
                    ModelState.AddModelError(string.Empty, "Hatalı email veya şifre girişi!");
                }
                else
                {
                    HttpContext.Session.SetString("user", model.Email);
                    return RedirectToAction("ConfirmAddress", _mapper.Map<CustomerViewModel>(customer));
                }
            }
            return View(model);
        }
        [HttpGet]
        public IActionResult ConfirmAddress(CustomerViewModel model)
        {
            if(HttpContext.Session.GetString("user") == null)
            {
                return RedirectToAction("Login");
            }
            return View(model);
        }
        [HttpPost]
        [ActionName("ConfirmAddress")]
        public IActionResult ConfirmToAddress(CustomerViewModel model)
        {
            if (ModelState.IsValid)
            {
                _customerRepo.Update(_mapper.Map<Customer>(model));
                return RedirectToAction("ConfirmPayment", model);
            }
            return View(model);
        }
        public IActionResult ConfirmPayment(CustomerViewModel model)
        {
            //Müşteri daha önceden login olmuş mu?
            if (HttpContext.Session.GetString("user") == null) //Olmadıysa login ekranına 
            {                                                   //geri döndürüyoruz.
                return RedirectToAction("Login");
            }
            //Müşteri (customer) bilgileri -> model var.

            //Sepet bilgileri  -> session("sepet")
            var sepet = HttpContext.Session.GetJson<List<SepetDetay>>("sepet");
            //ToplamAdet, ToplamTutar bilgileri -> session("sepet") aracılığıyla hesaplanabilir.
            SepetDetay sd = new SepetDetay();
            int ToplamAdet = sd.ToplamAdet(sepet);
            decimal ToplamTutar = sd.ToplamTutar(sepet);
            //Yeni bir movieSaleViewModel nesnesi oluşturup, gerekli bilgileri şimdiden aktarıyoruz.
            MovieSaleViewModel movieSaleViewModel = new MovieSaleViewModel();
            movieSaleViewModel.CustomerId = model.Id;
            movieSaleViewModel.Date = DateTime.Now;
            movieSaleViewModel.TotalQuantity = ToplamAdet;
            movieSaleViewModel.TotalPrice = ToplamTutar;

            CustomerFaturaViewModel customerFaturaViewModel = new CustomerFaturaViewModel()
            {
                customerViewModel = model,
                satisViewModel = movieSaleViewModel,
                sepetDetayListesi = sepet
            };

            return View(customerFaturaViewModel);
        }
        [HttpPost]
        public IActionResult ConfirmPayment(CustomerFaturaViewModel model)
        {
            //MovieSale nesnesi oluşturulup veritabanına satış kaydı açılacak.
            
            //Session'dan sepet çekilecek.

            //Bu kaydın Id'si kullanılarak MovieSaleDetails veritabanına kayıt edilecek.
            return View();
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(CustomerViewModel model)
        {
            if (ModelState.IsValid)
            {
                _customerRepo.Add(_mapper.Map<Customer>(model));
                return RedirectToAction("Index");
            }
            return View(model);
        }
    }
}
