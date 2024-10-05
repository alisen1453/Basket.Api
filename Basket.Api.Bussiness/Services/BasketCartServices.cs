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
        private readonly IRepository<Product> _productrepository;

        public BasketCartServices(IRepository<BasketCart> cartrepository, IRepository<Customer> customerrepository,
            IRepository<BasketItem> ıtemrepository, IRepository<Product> productrepository)
        {
            _cartrepository = cartrepository;
            _customerrepository = customerrepository;
            _Itemrepository = ıtemrepository;
            _productrepository=productrepository;
        }

        public async Task<ApiResponse<BasketCart>> AddCartOrGetCart(BasketItemDto item, bool isAdding = true)
        {
            // Müşterinin var olup olmadığını kontrol et
            var customerExists = await _customerrepository.Query().AnyAsync(c => c.CostumerId == item.CustomerId);

            if (!customerExists)
            {
                return new ApiResponse<BasketCart>(400, null, new List<string> { "Müşteri bulunamadı." });
            }

            // Mevcut sepeti bul veya yeni bir sepet oluştur
            var entity = await _cartrepository.Query()
                .Include(x => x.BasketItems)
                .FirstOrDefaultAsync(x => x.CustomerId == item.CustomerId);

            if (entity == null)
            {
                entity = new BasketCart { CustomerId = item.CustomerId };
                await _cartrepository.AddAsync(entity);
            }

            // Sepette aynı ürünün olup olmadığını kontrol et
            var existingItem = entity.BasketItems.FirstOrDefault(x => x.ProductId == item.ProductId);

            // Ürün zaten sepetteyse
            if (existingItem != null)
            {
                if (isAdding)
                {
                    // Ürün miktarını artır
                    existingItem.Quantity += item.Quantity;
                    var product = await _productrepository.Query().FirstOrDefaultAsync(p => p.ProductId == item.ProductId);
                    if (product != null)
                    {
                        product.StockQuantity -= item.Quantity;
                        await _productrepository.UpdateAsync(product);
                    }
                    await _cartrepository.UpdateAsync(entity);
                    

                    return new ApiResponse<BasketCart>(200, entity, new List<string> { "Ürün sepete eklendi." });
                }
                else
                {
                    // Ürün miktarını azalt
                    existingItem.Quantity -= item.Quantity;
                    var product = await _productrepository.Query().FirstOrDefaultAsync(p => p.ProductId == item.ProductId);
                    if (product != null)
                    {
                        product.StockQuantity += item.Quantity;
                        await _productrepository.UpdateAsync(product);
                    }

                    // Miktar sıfır veya daha az ise ürünü sepetten çıkar
                    if (existingItem.Quantity <= 0)
                    {
                        entity.BasketItems.Remove(existingItem);
                    }

                    await _cartrepository.UpdateAsync(entity);
                    return new ApiResponse<BasketCart>(200, entity, new List<string> { "Ürün sepetten eksiltildi." });
                }
            }

            // Sepette ürün yoksa ve eksiltme işlemi yapılmak isteniyorsa hata döndür
            if (!isAdding)
            {
                return new ApiResponse<BasketCart>(400, null, new List<string> { "Ürün sepetinizde bulunmamaktadır." });
            }

            // Stok kontrolü
            var matchingProduct = await _productrepository.Query()
                .Where(p => p.StockQuantity > 0)
                .FirstOrDefaultAsync(p => p.ProductId == item.ProductId);

            if (matchingProduct == null)
            {
                return new ApiResponse<BasketCart>(400, null, new List<string> { "Üründen stokta bulunmamaktadır." });
            }

            // Ürün sepete ekleniyor
            entity.BasketItems.Add(new BasketItem
            {
                BasketItemId=Guid.NewGuid(),
                BasketId = Guid.NewGuid(),
                ProductId = item.ProductId,
                Quantity = item.Quantity
            });
         
            var product1 = await _productrepository.Query().FirstOrDefaultAsync(p => p.ProductId == item.ProductId);
            if (product1 != null)
            {
                product1.StockQuantity -= item.Quantity;
                await _productrepository.UpdateAsync(product1);
            }

            await _cartrepository.UpdateAsync(entity);
            return new ApiResponse<BasketCart>(200, entity, new List<string> { "Ürünler sepete eklendi." });
        }//SepetEkleme
        public async Task<ApiResponse<IEnumerable<BasketItem>>> GetItemListAsync()
        {
            var entity = await _Itemrepository.GetAllAsync();

            return new ApiResponse<IEnumerable<BasketItem>>(200,entity, new List<string> { "Ürünler sepete eklendi." });

        }

    }
}