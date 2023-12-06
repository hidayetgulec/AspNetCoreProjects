using Microsoft.AspNetCore.Identity;

namespace AspNetCoreMvc_Identity_Authentication.Identity.Models
{
    public class AppRole : IdentityRole<int>
    {
        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}
