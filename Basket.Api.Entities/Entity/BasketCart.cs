using Basket.Api.Core.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Basket.Api.Entities.Entity
{
    public class BasketCart: IEntity
    {
        public Guid BasketId { get; set; }
        public Guid CustomerId { get; set; }
        [JsonIgnore]
        public Customer? Customer { get; set; }
       
        public List<BasketItem> BasketItems { get; set; } = new List<BasketItem>();


    }
}
