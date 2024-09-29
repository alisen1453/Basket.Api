using Basket.Api.Entities.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basket.Api.Access.Context
{
    public class BasketDbContext:DbContext
    {
        public BasketDbContext(DbContextOptions<BasketDbContext> options) : base(options)
        {
        }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<BasketItem> BasketItems { get; set; }
        public DbSet<BasketCart> BasketCarts { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().HasKey(c => c.CostumerId);

           
            modelBuilder.Entity<Product>().HasKey(c => c.ProductId);
            modelBuilder.Entity<BasketCart>().HasKey(c => c.BasketCartId);
            modelBuilder.Entity<BasketItem>().HasKey(c => c.BasketItemId);
            modelBuilder.Entity<Order>()
            .Property(o => o.TotalAmount)
            .HasPrecision(18, 2); // Toplam 18 basamak, virgülden sonra 2 basamak

            modelBuilder.Entity<OrderItem>()
                .Property(oi => oi.UnitPrice)
                .HasPrecision(18, 2); // 18 basamak, virgülden sonra 2 basamak

            modelBuilder.Entity<Product>()
                .Property(p => p.Price)
                .HasPrecision(18, 2); // 18 basamak, virgülden sonra 2 basamak

            modelBuilder.Entity<BasketItem>()
            .HasOne(ci => ci.Product)
            .WithMany()
            .HasForeignKey(ci => ci.ProductId);

            modelBuilder.Entity<BasketCart>()
                .HasMany(sc => sc.CartItems)
                .WithOne();
             modelBuilder.Entity<BasketCart>()
            .HasMany(b => b.CartItems)
            .WithOne(bi => bi.Basket)
            .HasForeignKey(bi => bi.BasketId) // Specify the foreign key here
            .OnDelete(DeleteBehavior.Cascade); // Configure delete behavior as needed

        // If you have another relationship, configure it explicitly as well
        //modelBuilder.Entity<BasketItem>()
        //    .HasOne(bi => bi.Ba) // Specify the navigation property
        //    .WithMany(bc => bc.BasketItems) // Specify the inverse navigation property
        //    .HasForeignKey(bi => bi.AnotherBasketId);



        }



    }
}
