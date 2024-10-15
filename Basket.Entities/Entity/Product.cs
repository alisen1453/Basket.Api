using Basket.Core.Abstract;

namespace Basket.Entities.Entity
{
    public class Product : IEntity
    {

        public Guid ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public List<CartItem> CartItems { get; set; }

        //public Product(string name, string description, decimal price, int stock)
        //{
        //    Name = name;
        //    Description = description;
        //    Price = price;
        //    Stock = stock;
        //    CartItems = new List<CartItem>();
        //}

        public void UpdateStock(int newStock)
        {
            Stock = newStock;
        }

    }
}
