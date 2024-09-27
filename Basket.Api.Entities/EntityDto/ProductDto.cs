using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basket.Api.Entities.EntityDto
{
    public class ProductDto
    {
        public string? Name { get; set; } // Ürünün adı.

        [Required]
        public decimal Price { get; set; } // Ürünün fiyatı.

        public int StockQuantity { get; set; } // Mevcut stok miktarı.
    }
}
