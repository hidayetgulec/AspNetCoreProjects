﻿// <auto-generated />
using AspNetCoreMvc_CodeFirst_Migrations.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AspNetCoreMvc_CodeFirst_Migrations.Migrations
{
    [DbContext(typeof(StockDataDBContext))]
    partial class StockDataDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AspNetCoreMvc_CodeFirst_Migrations.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Çeşitli bilgisayarlar",
                            Name = "Bilgisayar"
                        },
                        new
                        {
                            Id = 2,
                            Description = "Çeşitli telefonlar",
                            Name = "Telefon"
                        },
                        new
                        {
                            Id = 3,
                            Description = "Çeşitli yazıcılar",
                            Name = "Yazıcı"
                        });
                });

            modelBuilder.Entity("AspNetCoreMvc_CodeFirst_Migrations.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Details")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Stock")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryId = 1,
                            Details = "i7 işlemci",
                            ImageUrl = "/images/lenovoi7.jpg",
                            Name = "Lenovo i7",
                            Price = 40000m,
                            Stock = 12
                        },
                        new
                        {
                            Id = 2,
                            CategoryId = 1,
                            Details = "i5 işlemci",
                            ImageUrl = "/images/lenovoi5.jpg",
                            Name = "Lenovo i5",
                            Price = 33000m,
                            Stock = 12
                        },
                        new
                        {
                            Id = 3,
                            CategoryId = 2,
                            Details = "6.1 inch",
                            ImageUrl = "/images/IPhone13.jpg",
                            Name = "IPhone 13",
                            Price = 40000m,
                            Stock = 12
                        },
                        new
                        {
                            Id = 4,
                            CategoryId = 2,
                            Details = "6.7 inch",
                            ImageUrl = "/images/IPhone14.jpg",
                            Name = "IPhone 14",
                            Price = 60000m,
                            Stock = 22
                        },
                        new
                        {
                            Id = 5,
                            CategoryId = 3,
                            Details = "Laser jet",
                            ImageUrl = "/images/Hp.jpg",
                            Name = "Hp Laserjet",
                            Price = 6000m,
                            Stock = 5
                        });
                });

            modelBuilder.Entity("AspNetCoreMvc_CodeFirst_Migrations.Models.Product", b =>
                {
                    b.HasOne("AspNetCoreMvc_CodeFirst_Migrations.Models.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("AspNetCoreMvc_CodeFirst_Migrations.Models.Category", b =>
                {
                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}
