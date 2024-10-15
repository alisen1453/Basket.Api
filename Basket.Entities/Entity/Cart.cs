using Basket.Core.Abstract;

namespace Basket.Entities.Entity
{
    public class Cart : IEntity
    {
        public Guid CartId { get; set; }
        public DateTime CreatedDate { get; set; }
        public Guid CustomerId { get; set; }
        public Customer Customer { get; set; }
        public List<CartItem> CartItems { get; set; }

        //public Cart(Customer customer)
        //{
        //    Customer = customer;
        //    CreatedDate = DateTime.UtcNow;
        //    IsCheckedOut = false;
        //    CartItems = new List<CartItem>();
        //}

    }
}
