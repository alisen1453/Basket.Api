using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Basket.Api.Entities.EntityDto;

namespace Basket.Api.Bussiness.Abstract
{
    public interface IBasketItemServices
    {
        Task BasketItemAddOrUpdate(BasketItemDto basketItemDto);
    }
}
