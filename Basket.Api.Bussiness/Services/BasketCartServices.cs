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
    public class BasketCartServices:IBasketCartServices
    {
        private readonly IRepository<BasketCart> _repository;

        public BasketCartServices(IRepository<BasketCart> repository)
        {
            _repository = repository;
        }


    }
}
