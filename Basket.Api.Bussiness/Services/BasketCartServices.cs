using Azure;
using Basket.Api.Bussiness.Abstract;
using Basket.Api.Core.Abstract;
using Basket.Api.Core.Response;
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
    public class BasketCartServices : IBasketCartServices
    {
        private readonly IRepository<Cart> _cartrepository;
        private readonly IRepository<Customer> _customerrepository;
        private readonly IRepository<CartItem> _Itemrepository;
        private readonly IRepository<Product> _productrepository;

        public BasketCartServices(IRepository<Cart> cartrepository, IRepository<Customer> customerrepository,
            IRepository<CartItem> ıtemrepository, IRepository<Product> productrepository)
        {
            _cartrepository = cartrepository;
            _customerrepository = customerrepository;
            _Itemrepository = ıtemrepository;
            _productrepository = productrepository;
        }

        public async Task AddCartOrGetCart(BasketItemDto item, bool entry = true)
        {
            // Müşterinin var olup olmadığını kontrol et
            //  var customerExists = await _customerrepository.Query().AnyAsync(c => c.CustomerId == item.CustomerId);



            // Mevcut sepeti bul veya yeni bir sepet oluştur
            var entity = await _cartrepository.Query()
                .Include(x => x.CartItems).ThenInclude(x => x.Product)
                .FirstOrDefaultAsync(x => x.CustomerId == item.CustomerId);
            if (entity == null)
            {

                entity = new Cart { CustomerId = item.CustomerId };
                await _cartrepository.AddAsync(entity);

            }


            var product = await _productrepository.Query().AsTracking().
                FirstOrDefaultAsync(x => x.ProductId == item.ProductId);//Stok kontrolu.


            if (product != null)
            {

                var cartitem = entity.CartItems.FirstOrDefault(x => x.ProductId == item.ProductId);
                if (cartitem == null)
                {
                    //product sorgulama


                    //CartItem ürün ekeleme.
                    if (product.Stock <= item.Quantity) { throw new NotFoundException("Stok yetersiz"); }
                    else
                    {
                        entity.CartItems.Add(new CartItem
                        {
                            ProductId = item.ProductId,
                            Quantity = item.Quantity,
                            CartId = entity.CartId,

                        });
                        await _cartrepository.UpdateAsync(entity);

                        product.Stock -= item.Quantity;
                        await _productrepository.UpdateAsync(product);
                    }

                }
                else
                {

                    if (entry)
                    {
                        if (product.Stock <= item.Quantity) { throw new NotFoundException("Stok yetersiz"); }
                        else
                        {

                            cartitem.Quantity += item.Quantity;
                            await _cartrepository.UpdateAsync(entity);
                            product.Stock -= item.Quantity;
                            await _productrepository.UpdateAsync(product);
                        }
                    }
                    else
                    {
                        cartitem.Quantity -= item.Quantity;
                        await _cartrepository.UpdateAsync(entity);
                        product.Stock += item.Quantity;
                        await _productrepository.UpdateAsync(product);
                    }
                }

            }

        }

    }
}