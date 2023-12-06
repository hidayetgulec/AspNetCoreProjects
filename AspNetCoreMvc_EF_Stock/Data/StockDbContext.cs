using AspNetCoreMvc_EF_Stock.Models;
using Microsoft.EntityFrameworkCore;

namespace AspNetCoreMvc_EF_Stock.Data
{
    public class StockDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-Q99D8J1\\MSSQL2019; Initial Catalog=Stock; uid=sa; pwd=54321; TrustServerCertificate=true");
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}
