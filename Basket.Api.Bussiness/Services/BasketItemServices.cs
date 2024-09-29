using Basket.Api.Bussiness.Abstract;
using Basket.Api.Core.Abstract;
using Basket.Api.Entities.Entity;
using Basket.Api.Entities.EntityDto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basket.Api.Bussiness.Services
{
    public class BasketItemServices:IBasketItemServices
    {
        private readonly IRepository<BasketItem> _Itemrepository;
        private readonly IRepository<BasketCart> _cartRepository;
        private readonly IRepository<Product> _productRepository;


        public BasketItemServices(IRepository<BasketItem> ıtemrepository, 
            IRepository<BasketCart> cartRepository, IRepository<Product> productRepository)
        {
            _Itemrepository = ıtemrepository;
            _cartRepository = cartRepository;
            _productRepository = productRepository;
        }

        public Task BasketItemAddOrUpdate(BasketItemDto basketItemDto)
        {


            return Task.CompletedTask;
        }
    }
}
