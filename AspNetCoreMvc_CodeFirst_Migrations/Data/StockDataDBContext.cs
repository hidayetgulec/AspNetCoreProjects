using AspNetCoreMvc_CodeFirst_Migrations.Models;
using Microsoft.EntityFrameworkCore;

namespace AspNetCoreMvc_CodeFirst_Migrations.Data
{
    public class StockDataDBContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-Q99D8J1\\MSSQL2019; Initial Catalog=StockData; uid=sa; pwd=54321; TrustServerCertificate=true");
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Fluent API -> veritabanı yapılandırması için kullanıyoruz.
            modelBuilder.Entity<Product>().
                Property(p => p.ImageUrl).HasMaxLength(200);

            //Test Verileri Ekleme (Seed Data)
            modelBuilder.Entity<Category>().HasData(
                    new Category() { Id = 1, Name="Bilgisayar", Description="Çeşitli bilgisayarlar" },
                    new Category() { Id = 2, Name = "Telefon", Description = "Çeşitli telefonlar" },
                    new Category() { Id = 3, Name = "Yazıcı", Description = "Çeşitli yazıcılar" }
                );

            modelBuilder.Entity<Product>().HasData(
                    new Product() { Id = 1, Name = "Lenovo i7", Stock = 12, Price=40000, Details = "i7 işlemci", ImageUrl = "/images/lenovoi7.jpg", CategoryId = 1 },
                    new Product() { Id = 2, Name = "Lenovo i5", Stock = 12, Price = 33000, Details = "i5 işlemci", ImageUrl = "/images/lenovoi5.jpg", CategoryId = 1 },
                    new Product() { Id = 3, Name = "IPhone 13", Stock = 12, Price = 40000, Details = "6.1 inch", ImageUrl = "/images/IPhone13.jpg", CategoryId = 2 },
                    new Product() { Id = 4, Name = "IPhone 14", Stock = 22, Price = 60000, Details = "6.7 inch", ImageUrl = "/images/IPhone14.jpg", CategoryId = 2 },
                    new Product() { Id = 5, Name = "Hp Laserjet", Stock = 5, Price = 6000, Details = "Laser jet", ImageUrl = "/images/Hp.jpg", CategoryId = 3 }
    );
        }
    }
}
