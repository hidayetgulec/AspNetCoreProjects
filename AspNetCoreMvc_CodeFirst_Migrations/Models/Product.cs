using System.ComponentModel.DataAnnotations;

namespace AspNetCoreMvc_CodeFirst_Migrations.Models
{
    public class Product
    {
        public int Id { get; set; }
        [StringLength(100)]
        public string Name { get; set; }
        public int Stock { get; set; }
        public decimal Price { get; set; }
        public string Details { get; set; }
        public string ImageUrl { get; set; }

        public int CategoryId { get; set; }

        //Navigation property (relation)
        public Category Category { get; set; }
    }
}
