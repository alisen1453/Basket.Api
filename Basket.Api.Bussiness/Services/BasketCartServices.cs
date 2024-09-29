using Basket.Api.Bussiness.Abstract;
using Basket.Api.Core.Abstract;
using Basket.Api.Entities.Entity;
using Basket.Api.Entities.EntityDto;
using FreeDemoCatalog.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Basket.Api.Bussiness.Services
{
    public class BasketCartServices:IBasketCartServices
    {
        private readonly IRepository<BasketCart> _cart;
        private readonly IRepository<Customer> _customer;
        private readonly IRepository<BasketItem> _Item;

        public BasketCartServices(IRepository<BasketCart> cart, IRepository<Customer> customer
            , IRepository<BasketItem> Item)
        {
            _cart = cart;
            _customer = customer;
           _Item = Item;
        }
        public async Task<bool> AddCartOrGetCart(BasketItemDto item)
        {

            var entity = await _cart.GetById(item.CustomerId);
            if (entity == null)
            {
                var add = new BasketCart() { CustomerId = item.CustomerId };

                await _cart.AddAsync(add);
            }


                return await Task.FromResult(true); 
        }

       
        
        //        if (entity == null)
        //        {
        //            var add = new BasketCart() { CustomerId = CustomerId };

        //            await _cart.AddAsync(add);

        //        var Item= await _Item.GetById(CustomerId);
        //        if(Item == null)
        //        {
        //            var add2 = new BasketItem()
        //            {

        //            };
        //        }

        //        }//Kullanıcı Sepeti yoksasepet ekler.




        //}

    }
}
