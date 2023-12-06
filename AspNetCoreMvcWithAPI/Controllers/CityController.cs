using AspNetCoreMvcWithAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace AspNetCoreMvcWithAPI.Controllers
{
    public class CityController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public CityController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IActionResult> Index()
        {
            var http = _httpClientFactory.CreateClient(); //HttpClient nesnesi oluşur.
            var result = await http.GetAsync("https://localhost:7091/api/cities");
            if(result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var jsonData = await result.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<List<CityViewModel>>(jsonData);
                //Json Serialize işlemleri için NewtonSoft paketini yüklüyoruz.
                return View(data);
            }
            return View();
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CityViewModel model)
        {
            var http = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(model);
            var content = new StringContent(jsonData, encoding: Encoding.UTF8, "application/json");
            var result = await http.PostAsync("https://localhost:7091/api/cities", content);
            if(result.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        public async Task<IActionResult> Edit(int id)
        {
            var http = _httpClientFactory.CreateClient();
            //gelen id'ye sahip City bilgileri API'den çekilecek.
            var result = await http.GetAsync($"https://localhost:7091/api/cities/{id}");
            //result için de statuscode ve content var.
            var jsonData = await result.Content.ReadAsStringAsync();
            //json data deserialize edilip text'e dönüştürelecek.
            var data = JsonConvert.DeserializeObject<CityViewModel>(jsonData);
            return View(data);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(CityViewModel model)
        {
            var http = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(model);
            var content = new StringContent(jsonData, encoding: Encoding.UTF8, "application/json");
            var result = await http.PutAsync("https://localhost:7091/api/cities", content);
            if (result.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View(model);
        }
    }
}
