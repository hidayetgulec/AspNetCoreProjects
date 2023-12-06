using AspNetCoreMvc_DependencyInjection.Data;
using AspNetCoreMvc_DependencyInjection.Interfaces;
using AspNetCoreMvc_DependencyInjection.Models;

namespace AspNetCoreMvc_DependencyInjection.Repositories
{
    public class ProductRepository : IProductRepository
    {
        //StockDbContext _context = new StockDbContext();

        private readonly StockDbContext _context;
        public ProductRepository(StockDbContext context)  //Dependency Injection Design Pattern, constructor içinden bir nesne istendiği gördüğü anda DI container'a bakıyor, yoksa yenisini varsa olan nesneyi parametre olarak gönderiyor.
        {
            _context = context;
        }
        public List<Product> GetAllProducts()
        {
            return _context.Products.ToList();
        }
        public Product GetById(int id)
        {
            //return _context.Products.FirstOrDefault(c => c.Id == id);
            return _context.Products.Find(id);
        }
        public void Add(Product product)
        {
            _context.Products.Add(product); //ara katmana ekler.
            _context.SaveChanges(); //veritabanıyla eşleştirir.
        }
        public void Update(Product product)
        {
            _context.Products.Update(product);
            _context.SaveChanges();
        }
        public void Delete(Product product)
        {
            _context.Products.Remove(product);
            _context.SaveChanges();
        }
    }
}
