using Basket.Api.Entities.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basket.Api.Entities.EntityDto
{
     public class BasketCartDto
    {
        public Guid CustomerId { get; set; }
        public Customer? Customer { get; set; }
        public List<CartItem>? BasketItems { get; set; }
    }
}
