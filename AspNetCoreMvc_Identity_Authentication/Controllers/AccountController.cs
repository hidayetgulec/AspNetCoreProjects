using AspNetCoreMvc_Identity_Authentication.Identity.Models;
using AspNetCoreMvc_Identity_Authentication.Identity.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AspNetCoreMvc_Identity_Authentication.Controllers
{
    [AutoValidateAntiforgeryToken]
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public async Task<IActionResult> Index()
        {
            var users = await _userManager.Users.ToListAsync();
            var model = users.Select(u => new UserViewModel()
            {
                Id = u.Id,
                Username = u.UserName,
                Email = u.Email,
                FirstName = u.FirstName,
                LastName = u.LastName,
                PhoneNumber = u.PhoneNumber
            });
            return View(model);
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            var user = new AppUser()
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                PhoneNumber = model.PhoneNumber,
                UserName = model.Username
            };

            var identityResult = await _userManager.CreateAsync(user, model.ConfirmPassword);

            if(identityResult.Succeeded)
            {
                TempData["message"] = "Kullanıcı kayıt işlemi başarıyla gerçekleşti.";
                return RedirectToAction("Register");
            }
            foreach (var error in identityResult.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }

            return View(model);
        }
        public IActionResult Login(string? returnUrl)
        {
            LoginViewModel model = new LoginViewModel()
            {
                ReturnUrl = returnUrl
            };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            var user = await _userManager.FindByNameAsync(model.Username);

            if (user == null)
            {
                ModelState.AddModelError("", "Kullanıcı bulunamadı.");
                return View(model);
            }
            var signInResult =  await _signInManager.PasswordSignInAsync(user, model.Password, model.RememberMe, true);  //sondaki lockout (kilitleme) özelliğini true yaptık.
            //Aşağıdaki 3 şarttan sadece biri gerçekleşebilir.
            if(signInResult.Succeeded)
            {
                TempData["message"] = "Login işlemi başarılı.";
                //return RedirectToAction("Login");
                return Redirect(model.ReturnUrl ?? "~/");

            }
            if (signInResult.IsLockedOut)
            {
                TempData["message"] = "Login işlemi bir süreliğine kilitlenmiştir.";
                return RedirectToAction("Login");
            }
            //if (signInResult.IsNotAllowed)
            //{
                    //Email veya Telefon onayı istenmişse
            //}
            else
            {
                ModelState.AddModelError("", "Kullanıcı adı veya şifre hatalı");
            }

            return View(model);
        }
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
