using Basket.Api.Core.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Basket.Api.Entities.Entity
{
    public class Order:IEntity
    {
        public Guid OrderId { get; set; } // Siparişin benzersiz kimliği.

        public int CustomerId { get; set; } // Siparişi veren müşterinin kimliği.
        [JsonIgnore]
        public Customer? Customer { get; set; } // Siparişi veren müşteri bilgisi.
        [JsonIgnore]

        public DateTime OrderDate { get; set; } // Siparişin verildiği tarih.

        public decimal TotalAmount { get; set; } // Siparişin toplam tutarı.

        public List<OrderItem>? OrderItems { get; set; } // Siparişte yer alan ürünlerin listesi.
    }
}
