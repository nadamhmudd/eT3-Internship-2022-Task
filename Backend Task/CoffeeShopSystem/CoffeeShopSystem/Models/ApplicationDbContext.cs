using CoffeeShopSystem.Constant;
using CoffeeShopSystem.Models.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CoffeeShopSystem.Models
{
    public class ApplicationDbContext : IdentityDbContext<Staff>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            :base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Staff> Staff { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<OrderItem>()
                .HasKey(i => new { i.OrderId, i.ProductId, i.CupSize })
                ;

            #region Seed temp Data

            builder.Entity<Staff>().HasData(new Staff()
            {
                Id = "1",
                FullName = "Cahsier"
            });

            #region Products
            builder.Entity<Product>().HasData(new Product
            {
                Id = 1,
                Name = "Caffè Misto",
                Description = "2% Milk, Milk Foam, Steamed Hot",
                SmallCupSize_Price = 35,
                MediumCupSize_Price = 50,
                LargeCupSize_Price = 65,
                ExtraLargeCupSize_Price = 80 
            });
            builder.Entity<Product>().HasData(new Product
            {
                Id = 2,
                Name = "Cappuccinos",
                Description = "2% Milk, Regular Foam, Steamed Hot",
                SmallCupSize_Price = 40,
                MediumCupSize_Price = 65,
                LargeCupSize_Price = 80,
                ExtraLargeCupSize_Price = 99
            });
            builder.Entity<Product>().HasData(new Product
            {
                Id = 3,
                Name = "Cinnamon Dolce Latte",
                Description = "2% Milk, Milk Foam, Steamed Hot ",
                SmallCupSize_Price = 55,
                MediumCupSize_Price = 70,
                LargeCupSize_Price = 85,
                ExtraLargeCupSize_Price = 110
            });
            builder.Entity<Product>().HasData(new Product
            {
                Id = 4,
                Name = "Espresso",
                Description = "2 Shots Signature Espresso",
                SmallCupSize_Price = 25,
                MediumCupSize_Price = 50,
                LargeCupSize_Price = 75,
                ExtraLargeCupSize_Price = 90
            });
            builder.Entity<Product>().HasData(new Product
            {
                Id = 5,
                Name = "Flat White",
                Description = "Whole Milk, Steamed Hot",
                SmallCupSize_Price = 35,
                MediumCupSize_Price = 50,
                LargeCupSize_Price = 60,
                ExtraLargeCupSize_Price = 85
            });
            builder.Entity<Product>().HasData(new Product
            {
                Id = 6,
                Name = "Caffè Latte",
                Description = "2% Milk, Milk Foam, Steamed Hot",
                SmallCupSize_Price = 45,
                MediumCupSize_Price = 55,
                LargeCupSize_Price = 65,
                ExtraLargeCupSize_Price = 75
            });
            #endregion

            builder.Entity<Staff>().HasData(new Staff()
            {
                Id = "n1aea1a1-6b4a-44db-a057-061cf7aeb8nn",
                FullName = "Cahsier",
            });

            #region Orders
            builder.Entity<Order>().HasData(new Order
            {
                Id = 1,
                OrderDate = DateTime.UtcNow,
                OrderStatus = ((SD.Status)SD.Status.Processing).ToString(),
                OrderTotal = 145,
                CashierId = "n1aea1a1-6b4a-44db-a057-061cf7aeb8nn"
            });
            builder.Entity<Order>().HasData(new Order
            {
                Id = 2,
                OrderDate = DateTime.UtcNow,
                OrderStatus = ((SD.Status)SD.Status.Processing).ToString(),
                OrderTotal = 140,
                CashierId = "n1aea1a1-6b4a-44db-a057-061cf7aeb8nn"
            });
            #endregion

            #region Order Items
            builder.Entity<OrderItem>().HasData(new OrderItem
            {
                ProductId = 1,
                OrderId = 1,
                CupSize = "Small",
                Quantity = 2,
                Price = 35,
            });
            builder.Entity<OrderItem>().HasData(new OrderItem
            {
                ProductId = 4,
                OrderId = 1,
                CupSize = "Large",
                Quantity = 1,
                Price = 75,
            });
            builder.Entity<OrderItem>().HasData(new OrderItem
            {
                ProductId = 2,
                OrderId = 2,
                CupSize = "Medium",
                Quantity = 1,
                Price = 65,
            });
            builder.Entity<OrderItem>().HasData(new OrderItem
            {
                ProductId = 6,
                OrderId = 2,
                CupSize = "ExtraLarge",
                Quantity = 1,
                Price = 75,
            });
            #endregion

            #endregion

            base.OnModelCreating(builder);
        }
    }
}
