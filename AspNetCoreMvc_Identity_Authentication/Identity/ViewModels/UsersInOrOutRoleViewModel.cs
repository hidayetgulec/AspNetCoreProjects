using AspNetCoreMvc_Identity_Authentication.Identity.Models;

namespace AspNetCoreMvc_Identity_Authentication.Identity.ViewModels
{
    public class UsersInOrOutRoleViewModel
    {
        public AppRole Role { get; set; }
        public List<AppUser> UsersInRole { get; set; }
        public List<AppUser> UsersOutRole { get; set; }
    }
}
