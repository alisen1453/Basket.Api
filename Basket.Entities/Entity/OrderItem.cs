using Basket.Core.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Basket.Entities.Entity
{
    public class OrderItem : IEntity
    {
        public Guid OrderItemId { get; set; } // Sipariş öğesinin benzersiz kimliği.

        public int OrderId { get; set; } // Siparişin kimliği.
        public Order? Order { get; set; } // Sipariş bilgisi.

        public Guid ProductId { get; set; } // Ürünün kimliği.
        [JsonIgnore]
        public Product? Product { get; set; } // Sipariş edilen ürün bilgisi.

        public int Quantity { get; set; } // Sipariş edilen ürün miktarı.
        public decimal UnitPrice { get; set; } // Ürünün birim fiyatı.
    }
}
