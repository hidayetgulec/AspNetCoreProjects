using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AspNetCoreMvc_FormValidation.Models
{
    [Table("Products")]
    public class Product
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Ürün adını girmelisiniz!")]
        [StringLength(50, ErrorMessage = "En fazla 50 karakter girebilirsiniz!")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Stok miktarı girmelisiniz!")]
        [Range(1, 10, ErrorMessage = "1-10 arası bir değer girmelisiniz!")]
        public int? Stock { get; set; }
        [Required(ErrorMessage = "Fiyat bilgisi girmelisiniz!")]
        [Range(0, 100000, ErrorMessage = "0-100000 arasında bir değer girmelisiniz!")]
        public decimal? Price { get; set; }
        public string Details { get; set; }
        public string ImageUrl { get; set; }
        [DisplayName("Kategori")]
        public int CategoryId { get; set; }
    }
}
