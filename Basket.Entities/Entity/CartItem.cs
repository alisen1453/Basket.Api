using Basket.Core.Abstract;

namespace Basket.Entities.Entity
{
    public class CartItem : IEntity
    {
        public Guid CartItemId { get; set; }
        public int Quantity { get; set; }
        public Guid CartId { get; set; }
        public Guid ProductId { get; set; }
        public Cart Cart { get; set; }
        public Product Product { get; set; }
        public DateTime UpdateTime { get; set; }


        //public CartItem(Cart cart, Product product, int quantity)
        //{
        //    Cart = cart;
        //    Product = product;
        //    Quantity = quantity;
        //}

        public void UpdateQuantity(int newQuantity)
        {
            Quantity = newQuantity;
        }
    }
}

