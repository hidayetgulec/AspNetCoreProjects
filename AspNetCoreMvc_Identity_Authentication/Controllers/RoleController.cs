using AspNetCoreMvc_Identity_Authentication.Identity.Models;
using AspNetCoreMvc_Identity_Authentication.Identity.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AspNetCoreMvc_Identity_Authentication.Controllers
{
    public class RoleController : Controller
    {
        private readonly RoleManager<AppRole> _roleManager;
        private readonly UserManager<AppUser> _userManager;

        public RoleController(RoleManager<AppRole> roleManager, UserManager<AppUser> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }
        public async Task<IActionResult> Index()
        {
            var roles = await _roleManager.Roles.ToListAsync();
            var model = roles.Select(r => new RoleViewModel()
            {
                Id = r.Id,
                RoleName = r.Name,
                CreatedDate = r.CreatedDate
            });
            return View(model);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(RoleViewModel model)
        {
            var role = new AppRole()
            {
                Name = model.RoleName,
            };
            var result = await _roleManager.CreateAsync(role);
            if (result.Succeeded)
                return RedirectToAction("Index");
            else
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
                //ModelState.AddModelError("", "Rol kayıt işlemi gerçekleşmedi.");
            }
            return View(model);
        }
        public async Task<IActionResult> Edit(string id)
        {
            //Edit yapılacak rol bulunacak.
            var role = await _roleManager.FindByIdAsync(id);

            var usersInRole = new List<AppUser>();
            var usersOutRole = new List<AppUser>();

            var users = await _userManager.Users.ToListAsync();

            foreach (var user in users)
            {
                if(await _userManager.IsInRoleAsync(user, role.Name))
                {
                    usersInRole.Add(user);  //Bu rolde bulunan kullanıcıların listesi
                }
                else
                {
                    usersOutRole.Add(user); //Bu rolde olmayan kullanıcıların listesi
                }
            }                   
            UsersInOrOutRoleViewModel model = new UsersInOrOutRoleViewModel()
            {
                Role = role,
                UsersInRole = usersInRole,
                UsersOutRole = usersOutRole
            };

            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(UsersInOrOutRoleViewModel model)
        {
            
            return RedirectToAction("Edit", "Role", new {Id = model.Role.Id});
        }
    }
}
