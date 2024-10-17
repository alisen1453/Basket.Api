using Basket.Core.Abstract;

namespace Basket.Entities.Entity
{
    public class Product : IEntity
    {


        public Guid ProductId { get; set; } // Ürün ID'si
        public string Name { get; set; }     // Ürün adı
        public string Description { get; set; } // Ürün açıklaması
        public decimal Price { get; set; }    // Ürün fiyatı
        public int Stock { get; set; }        // Stok miktarı

        // İlişki
        public ICollection<CartItem> CartItems { get; set; } = new List<CartItem>();

    }
}