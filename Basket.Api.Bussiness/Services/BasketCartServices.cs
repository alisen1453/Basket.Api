using Azure;
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
    public class BasketCartServices : IBasketCartServices
    {
        private readonly IRepository<BasketCart> _cartrepository;
        private readonly IRepository<Customer> _customerrepository;
        private readonly IRepository<BasketItem> _Itemrepository;

        public BasketCartServices(IRepository<BasketCart> cartrepository, IRepository<Customer> customerrepository, IRepository<BasketItem> ıtemrepository)
        {
            _cartrepository = cartrepository;
            _customerrepository = customerrepository;
            _Itemrepository = ıtemrepository;
        }

        public async Task<ApiResponse<BasketCart>> AddCartOrGetCart(BasketItemDto item)
        {
            // Check if the customer exists
            var customerExists = await _cartrepository.Query().AnyAsync(c => c.CustomerId == item.CustomerId);
            if (!customerExists)
            {
                return new ApiResponse<BasketCart>(400, null, new List<string> { "Customer does not exist." });
            }

            var entity = await _cartrepository.Query()
                .Include(x => x.BasketItems)
                .FirstOrDefaultAsync(x => x.CustomerId == item.CustomerId);
            if (entity == null)
            {
                entity = new BasketCart { CustomerId = item.CustomerId };
                await _cartrepository.AddAsync(entity);
            }
            var data = _Itemrepository.Query().Where(x => x.Quantity > 0 && x.ProductId == item.ProductId).FirstOrDefaultAsync();
            if (data==null)
            {
                return new ApiResponse<BasketCart>(400, null, new List<string> { "Üründen Stokta bulunmamaktadır.." });
            }
            

                if (entity.BasketItems.Any(x => x.ProductId == item.ProductId))
                {
                    return new ApiResponse<BasketCart>(400, null, new List<string> { "Item already exists in the cart." });
                }
                else
                {

                    entity.BasketItems.Add(new BasketItem
                    {
                        BasketId = entity.BasketCartId,
                        ProductId = item.ProductId,
                        Quantity = item.Quantity
                    });
                    
                    return new ApiResponse<BasketCart>(200, entity, new List<string> { "Item added to cart successfully." });
                }
            
        }
    }
}