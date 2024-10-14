using Azure;
using Basket.Entities.Entity;
using Basket.Entities.EntityDto;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basket.Bussiness.Abstract
{
    public interface IBasketCartServices
    {
        Task AddCartOrGetCart(BasketItemDto item, bool entry = true);
        Task<Cart> GetItemListAsync(Guid id);
    }
}
