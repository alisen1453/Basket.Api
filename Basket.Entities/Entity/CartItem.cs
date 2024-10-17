using Basket.Core.Abstract;

namespace Basket.Entities.Entity
{
    public class CartItem : IEntity
    {
        public Guid CartItemId { get; set; } // Sepet öğesi ID'si
        public Guid CartId { get; set; }      // Sepet ID'si
        public Guid ProductId { get; set; }   // Ürün ID'si
        public int Quantity { get; set; }      // Miktar
        public DateTime UpdateTime { get; set; } // Güncelleme zamanı

        // İlişkiler
        public Cart Cart { get; set; }        // Her CartItem bir Cart'a aittir
        public Product Product { get; set; }   // Her CartItem bir Product'a sahiptir
    }
}

