using AspNetCoreMvc_DependencyInjection.Models;
using Microsoft.EntityFrameworkCore;

namespace AspNetCoreMvc_DependencyInjection.Data
{
    public class StockDbContext : DbContext
    {
        public StockDbContext(DbContextOptions<StockDbContext> options) : base(options) { }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Data Source=DESKTOP-Q99D8J1\\MSSQL2019; Initial Catalog=Stock; uid=sa; pwd=54321; TrustServerCertificate=true");
        //}

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}
