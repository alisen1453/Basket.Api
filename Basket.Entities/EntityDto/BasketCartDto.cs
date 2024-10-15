using Basket.Entities.Entity;

namespace Basket.Entities.EntityDto
{
    public class BasketCartDto
    {
        public Guid CustomerId { get; set; }
        public Customer? Customer { get; set; }
        public List<CartItem>? BasketItems { get; set; }
    }
}
