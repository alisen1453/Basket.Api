﻿using Basket.Api.Core.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basket.Api.Entities.Entity
{
    public class BasketItem:IEntity
    {
        public Guid BasketItemId { get; set; } // Sepet öğesinin benzersiz kimliği.

        public Guid BasketId { get; set; } // Sepetin kimliği.
        public BasketCart? Basket { get; set; } // Sepet bilgisi.

        public Guid ProductId { get; set; } // Ürünün kimliği.
        public Product? Product { get; set; } // Sepete eklenen ürün bilgisi.

        public Guid Quantity { get; set; } // Sepete eklenen ürünün miktarı.
        
    }
}