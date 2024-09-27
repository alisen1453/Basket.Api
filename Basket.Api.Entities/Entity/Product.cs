using Basket.Api.Core.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basket.Api.Entities.Entity
{
    public class Product : IEntity
    {
        public Guid ProductId { get; set; } // Ürünün benzersiz kimliği.

        
        public string? Name { get; set; } // Ürünün adı.

       
        public decimal Price { get; set; } // Ürünün fiyatı.

        public int StockQuantity { get; set; } // Mevcut stok miktarı.
    }
}
