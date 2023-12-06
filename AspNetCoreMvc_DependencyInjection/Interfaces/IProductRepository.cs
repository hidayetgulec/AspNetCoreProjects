using AspNetCoreMvc_DependencyInjection.Models;
using Microsoft.EntityFrameworkCore;

namespace AspNetCoreMvc_DependencyInjection.Interfaces
{
    public interface IProductRepository
    {
        public List<Product> GetAllProducts();
        public Product GetById(int id);
        public void Add(Product product);
        public void Update(Product product);
        public void Delete(Product product);
    }
}
