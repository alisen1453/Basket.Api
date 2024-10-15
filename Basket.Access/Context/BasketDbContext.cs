﻿using Basket.Entities.Entity;
using Microsoft.EntityFrameworkCore;

namespace Basket.Access.Context
{
    public class BasketDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }

        public BasketDbContext(DbContextOptions<BasketDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cart>()
            .HasOne(c => c.Customer)
            .WithMany(cu => cu.Carts)
            .HasForeignKey(c => c.CustomerId);

            // Cart-Item ilişkisi (Bir sepette birçok öğe olabilir)
            modelBuilder.Entity<CartItem>()
                .HasOne(i => i.Cart)
                .WithMany(c => c.CartItems)
                .HasForeignKey(i => i.CartId);
            modelBuilder.Entity<Product>().Property(c => c.Price)
                .HasColumnType("decimal(18,2)");



            modelBuilder.Entity<CartItem>()
                 .HasOne(ci => ci.Product)          // Her CartItem bir Product'a sahiptir
                 .WithMany(p => p.CartItems)       // Her Product birçok CartItem'a sahip olabilir
                 .HasForeignKey(ci => ci.ProductId); // CartItem'daki ProductId dış anahtar olarak

            base.OnModelCreating(modelBuilder);
        }
    }
}
