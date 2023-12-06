using System.ComponentModel.DataAnnotations;

namespace AspNetCoreMvc_Identity_Authentication.Identity.ViewModels
{
    public class RoleViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Rol ismi mutlaka girilmelidir.")]
        public string RoleName { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}
