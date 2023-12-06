using AspNetCoreMvc_Identity_Authentication.Data;
using AspNetCoreMvc_Identity_Authentication.Identity.Models;

namespace AspNetCoreMvc_Identity_Authentication.Extensions
{
    public static class StartExtensions
    {
        public static void AddIdentityExtensions(this IServiceCollection services)
        {
            services.AddIdentity<AppUser, AppRole>(
            opt =>
            {
                opt.Password.RequireNonAlphanumeric = false;
                opt.Password.RequiredLength = 3;
                opt.Password.RequireUppercase = false;
                opt.Password.RequireLowercase = false;
                opt.Password.RequireDigit = false;

                //opt.User.AllowedUserNameCharacters = "abcdefghijklmnoprstuvyzqw0123456789";

                opt.User.RequireUniqueEmail = true;

                opt.Lockout.MaxFailedAccessAttempts = 3;    //default : 5
                opt.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(1); //default 5 dk
            }
            ).AddEntityFrameworkStores<AppDbContext>();

            services.ConfigureApplicationCookie(opt =>
            {
                opt.LoginPath = new PathString("/Account/Login");
                opt.LogoutPath = new PathString("/Account/Logout");
                opt.ExpireTimeSpan = TimeSpan.FromMinutes(10);
                opt.SlidingExpiration = true; //10 dk dolmadan kullanıcı login olursa süre baştan başlar.
                opt.Cookie = new CookieBuilder()
                {
                    Name = "Identity.App.Cookie",
                    HttpOnly = true
                };
            });         
        }
    }
}
