using AspNetCoreMvc_FormValidation.Data;
using AspNetCoreMvc_FormValidation.Models;

namespace AspNetCoreMvc_FormValidation.Repositories
{
    public class ProductRepository
    {
        StockDbContext _context = new StockDbContext();
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
