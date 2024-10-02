using Basket.Api.Core.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basket.Api.Entities.Entity
{
    public class BasketCart: IEntity
    {
        public Guid BasketCartId { get; set; }
        public Guid CustomerId { get; set; }
        public Customer? Customer { get; set; }
        public List<BasketItem> BasketItems { get; set; } = new List<BasketItem>();


    }
}
