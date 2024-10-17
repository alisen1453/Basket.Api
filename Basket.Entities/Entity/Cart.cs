using Basket.Core.Abstract;
using System.ComponentModel.DataAnnotations.Schema;

namespace Basket.Entities.Entity
{


    public class Cart : IEntity
    {
        public Guid CartId { get; set; }     // Sepet ID'si
        public DateTime CreatedDate { get; set; } // Oluşturulma tarihi
        public Guid CustomerId { get; set; }  // Müşteri ID'si

        // İlişkiler
        public Customer Customer { get; set; } // Bir sepetin bir müşterisi vardır
        public ICollection<CartItem> CartItems { get; set; } = new List<CartItem>();
    }
}