using System.ComponentModel.DataAnnotations;

namespace AspNetCoreMvc_CodeFirst_Migrations.Models
{
    public class Category
    {
        public int Id { get; set; }
        [StringLength(100)]
        public string Name { get; set; }
        public string Description { get; set; }

        //Navigation property (relation)
        public List<Product> Products { get; set; }
    }
}
