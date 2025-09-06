using Clothes.Models;
using Microsoft.EntityFrameworkCore;

namespace Clothes.Data
{
    public class ShopContext:DbContext
    {
        public ShopContext(DbContextOptions<ShopContext> options) : base(options)
        {

        }

        public DbSet<Category> Category { get; set; }
        public DbSet<product> product { get; set; }
        public DbSet<ProductSize> ProductSize { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<OrderItem> OrderItem { get; set; }
        public DbSet<Order> Order {  get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData
                (
                new Category
                {
                    Id = 1,
                    Name = "men"
                },
                new Category
                {
                    Id = 2,
                    Name = "women"
                }
                );
            modelBuilder.Entity<product>().Ignore(p => p.Sizes);

            modelBuilder.Entity<product>().HasData
                (
                new product
                {
                    ID = 1,
                    Title = "Under Armour Men's UA Rival Fleece Hoodie Sweatshirt",
                    Description = "Prices for items sold by Amazon include VAT. Depending on your delivery address, VAT may vary at Checkout. For other items",
                    Price = 45,
                    gender = (product.GenderType)1,
                    ImagePath = "/images/man/hoodie-in-blue_02.webp",
                    CategoryID = 1
                },
                new product
                {
                    ID = 2,
                    Title = "Bershka Cropped denim jacket in light blue",
                    Description = "Serving new-new fashion and the best of basics, Bershka gets its inspiration from the latest music, technology and social media trends. Think jeans that hit different, fresh new outerwear, all-over-print dresses and cosy knitwear and sweats – when we say this brand has you covered, we’re not kidding. Scroll the Bershka at ASOS edit and get to know our pick of its clothing, shoes and accessories. Next stop: checkout.",
                    Price = 80,
                    gender= (product.GenderType)2,
                    ImagePath = "/images/woman/Jacket-_-Sun-Bleached_02.webp",
                    CategoryID = 2
                }
                );
            modelBuilder.Entity<ProductSize>().HasData
                (
                new ProductSize
                {
                    Id = 1,
                    Sizes = "L",
                    Stock = 5,
                    ProductID = 1
                },
                new ProductSize
                {
                    Id = 2,
                    Sizes = "XL",
                    Stock = 3,
                    ProductID = 1
                },
                new ProductSize
                {
                    Id = 3,
                    Sizes = "M",
                    Stock = 4,
                    ProductID = 1
                },
                new ProductSize
                {
                    Id = 4,
                    Sizes = "M",
                    Stock = 1,
                    ProductID = 2
                },
                new ProductSize
                {
                    Id = 5,
                    Sizes = "L",
                    Stock = 2,
                    ProductID = 2
                }

                );
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    FirstName = "Admin",
                    LastName = "admin",
                    Email = "admin@gmail.com",
                    Password = "Password",
                    IsAdmin = true,
                });
        }
       
    }
}
