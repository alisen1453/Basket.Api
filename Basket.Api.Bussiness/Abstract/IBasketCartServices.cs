using Azure;
using Basket.Api.Core.Abstract;
using Basket.Api.Entities.Entity;
using Basket.Api.Entities.EntityDto;
using FreeDemoCatalog.Entities;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basket.Api.Bussiness.Abstract
{
    public interface IBasketCartServices
    {
        Task AddCartOrGetCart(BasketItemDto item,bool entry = true);
        //Task<ApiResponse<IEnumerable<CartItem>>> GetItemListAsync();
    }
}
