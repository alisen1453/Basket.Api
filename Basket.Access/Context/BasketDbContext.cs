using Basket.Entities.Entity;
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
                .HasOne(c => c.Customer)    // Navigasyon özelliği
                .WithMany(cu => cu.Carts)   // Bir müşteri birden fazla sepete sahip
                .HasForeignKey(c => c.CustomerId);   // İlişkiyi belirtiyoruz

            modelBuilder.Entity<CartItem>()
                .HasOne(i => i.Cart)        // Her CartItem bir Cart'a sahiptir
                .WithMany(c => c.CartItems) // Bir Cart birçok CartItem'a sahip
                .HasForeignKey(i => i.CartId);

            modelBuilder.Entity<CartItem>()
                .HasOne(ci => ci.Product)    // Her CartItem bir Product'a sahiptir
                .WithMany(p => p.CartItems)  // Her Product birçok CartItem'a sahip
                .HasForeignKey(ci => ci.ProductId); // CartItem'daki ProductId dış anahtar olarak

            modelBuilder.Entity<Product>()
                .Property(c => c.Price)
                .HasColumnType("decimal(18,2)"); // Fiyatın veri türünü belirliyoruz

            base.OnModelCreating(modelBuilder);
        }
    }
}
