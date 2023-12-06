namespace AspNetCoreMvc_DependencyInjection.ViewModels
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? Stock { get; set; }
        public decimal? Price { get; set; }
        public string Details { get; set; }
        public string ImageUrl { get; set; }
        public int CategoryId { get; set; }
    }
}
