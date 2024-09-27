using Basket.Api.Bussiness.Abstract;
using Basket.Api.Core.Abstract;
using Basket.Api.Entities.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basket.Api.Bussiness.Services
{
    public class BasketItemServices:IBasketItemServices
    {
        private readonly IRepository<BasketItem> _repository;

        public BasketItemServices(IRepository<BasketItem> repository)
        {
            _repository = repository;
        }
    }
}
