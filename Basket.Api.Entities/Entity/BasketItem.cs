using Basket.Api.Core.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Basket.Api.Entities.Entity
{
    public class BasketItem:IEntity
    {
        public Guid BasketItemId { get; set; } // Sepet öğesinin benzersiz kimliği.

        public Guid BasketId { get; set; } // Sepetin kimliği.
        [JsonIgnore]
        public BasketCart BasketCart { get; set; } // Sepet bilgisi.

        public Guid ProductId { get; set; } // Ürünün kimliği.
        public Product Product { get; set; } // Sepete eklenen ürün bilgisi.

        public int Quantity { get; set; } // Sepete eklenen ürünün miktarı.

      

    }
}
