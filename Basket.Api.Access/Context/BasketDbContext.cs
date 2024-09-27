﻿using Basket.Api.Entities.Entity;
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

        }



    }
}
