﻿// <auto-generated />
using System;
using Basket.Api.Access.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Basket.Api.Services.Migrations
{
    [DbContext(typeof(BasketDbContext))]
    partial class BasketDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Basket.Api.Entities.Entity.BasketCart", b =>
                {
                    b.Property<Guid>("BasketCartId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CustomerId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("BasketCartId");

                    b.HasIndex("CustomerId")
                        .IsUnique();

                    b.ToTable("BasketCarts");
                });

            modelBuilder.Entity("Basket.Api.Entities.Entity.BasketItem", b =>
                {
                    b.Property<Guid>("BasketItemId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("BasketId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("BasketItemId");

                    b.HasIndex("ProductId");

                    b.ToTable("BasketItems");
                });

            modelBuilder.Entity("Basket.Api.Entities.Entity.Customer", b =>
                {
                    b.Property<Guid>("CostumerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CostumerId");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("Basket.Api.Entities.Entity.Order", b =>
                {
                    b.Property<Guid>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CustomerCostumerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("TotalAmount")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("OrderId");

                    b.HasIndex("CustomerCostumerId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("Basket.Api.Entities.Entity.OrderItem", b =>
                {
                    b.Property<Guid>("OrderItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<Guid?>("OrderId1")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<decimal>("UnitPrice")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("OrderItemId");

                    b.HasIndex("OrderId1");

                    b.HasIndex("ProductId");

                    b.ToTable("OrderItems");
                });

            modelBuilder.Entity("Basket.Api.Entities.Entity.Product", b =>
                {
                    b.Property<Guid>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("StockQuantity")
                        .HasColumnType("int");

                    b.HasKey("ProductId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("Basket.Api.Entities.Entity.BasketCart", b =>
                {
                    b.HasOne("Basket.Api.Entities.Entity.Customer", "Customer")
                        .WithOne("Baskets")
                        .HasForeignKey("Basket.Api.Entities.Entity.BasketCart", "CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("Basket.Api.Entities.Entity.BasketItem", b =>
                {
                    b.HasOne("Basket.Api.Entities.Entity.BasketCart", "BasketCart")
                        .WithMany("CartItems")
                        .HasForeignKey("BasketItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Basket.Api.Entities.Entity.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BasketCart");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Basket.Api.Entities.Entity.Order", b =>
                {
                    b.HasOne("Basket.Api.Entities.Entity.Customer", "Customer")
                        .WithMany("Orders")
                        .HasForeignKey("CustomerCostumerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("Basket.Api.Entities.Entity.OrderItem", b =>
                {
                    b.HasOne("Basket.Api.Entities.Entity.Order", "Order")
                        .WithMany("OrderItems")
                        .HasForeignKey("OrderId1");

                    b.HasOne("Basket.Api.Entities.Entity.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Basket.Api.Entities.Entity.BasketCart", b =>
                {
                    b.Navigation("CartItems");
                });

            modelBuilder.Entity("Basket.Api.Entities.Entity.Customer", b =>
                {
                    b.Navigation("Baskets");

                    b.Navigation("Orders");
                });

            modelBuilder.Entity("Basket.Api.Entities.Entity.Order", b =>
                {
                    b.Navigation("OrderItems");
                });
#pragma warning restore 612, 618
        }
    }
}
