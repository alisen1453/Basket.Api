using Basket.Api.Core.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basket.Api.Entities.Entity
{
    public class Customer:IEntity
    {
        public Guid CostumerId { get; set; } // Müşterinin benzersiz kimliği.

        
        public string? Name { get; set; } // Müşterinin adı.

       
        public string? Email { get; set; } // Müşterinin e-posta adresi.

        public List<Order>? Orders { get; set; } // Müşterinin yaptığı siparişler.
        public BasketCart? Baskets { get; set; } // Müşterinin sahip olduğu sepetler.
    }
}
