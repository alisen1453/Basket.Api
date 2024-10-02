using Basket.Api.Entities.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basket.Api.Entities.EntityDto
{
    public class BasketItemDto
    {
        

        //public Guid BasketId { get; set; } // Sepetin kimliği.

        public Guid ProductId { get; set; } // Ürünün kimliği.

        public int Quantity { get; set; } // Sepete eklenen ürünün miktarı.
        public Guid CustomerId { get; set; }
    }
}
