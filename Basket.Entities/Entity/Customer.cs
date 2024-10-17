using Basket.Core.Abstract;
using System.ComponentModel.DataAnnotations.Schema;

namespace Basket.Entities.Entity
{
    public class Customer : IEntity
    {

        public Guid CustomerId { get; set; } // Müşteri ID'si
        public string Email { get; set; }     // Müşteri e-posta adresi
        public string FirstName { get; set; } // Müşteri adı
        public string LastName { get; set; }  // Müşteri soyadı

        // İlişki
        public ICollection<Cart> Carts { get; set; } = new List<Cart>();


    }
}