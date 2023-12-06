using Microsoft.AspNetCore.Identity;

namespace AspNetCoreMvc_Identity_Authentication.Identity.Models
{
    public class AppUser : IdentityUser<int>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
