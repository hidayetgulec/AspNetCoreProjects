using AspNetCoreMvc_Identity_Authentication.Identity.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using AspNetCoreMvc_Identity_Authentication.Identity.ViewModels;

namespace AspNetCoreMvc_Identity_Authentication.Data
{
    public class AppDbContext : IdentityDbContext<AppUser, AppRole, int>
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
            
        }
        public DbSet<AspNetCoreMvc_Identity_Authentication.Identity.ViewModels.UserViewModel> UserViewModel { get; set; } = default!;
        public DbSet<AspNetCoreMvc_Identity_Authentication.Identity.ViewModels.RoleViewModel> RoleViewModel { get; set; } = default!;


    }
}
